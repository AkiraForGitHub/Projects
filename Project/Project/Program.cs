using Microsoft.EntityFrameworkCore;
using Project.Features;
using Project.Interface;
using Project.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProductContext>(options =>
{
options.UseSqlServer(builder.Configuration.GetConnectionString("Product"));
});
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("Web", c =>
    {
        c
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
    });
});
builder.Services.AddScoped<IProductFeatures, ProductFeatures>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("Web");

app.MapControllers();

app.Run();
