using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Interface;
using Project.Models;

namespace Project.Features
{
   
    public class ProductFeatures : IProductFeatures
    {
        private readonly ProductContext _ProductDb;

        public  ProductFeatures(ProductContext productDb)
        {
            _ProductDb = productDb;
        }

        public HttpResponse Response { get; set; }

        public void AddOnce([FromBody] Product ProductInfo)
        {
            Message Stausmsg = new Message();
            _ProductDb.Entry<Product>(ProductInfo).State = EntityState.Added;
            try
            {
                _ProductDb.SaveChanges();
                Stausmsg.msg = "新增成功";
            }
            catch
            {
                HttpResponse response = this.Response;
                response.StatusCode = 400;
                Stausmsg.msg = "新增失敗";
            }
        }

        public void DeleteProduct([FromQuery(Name = "id")] int id)
        {
            var info = _ProductDb.Products.Where(p => p.ProductId == id).FirstOrDefault<Product>();
            _ProductDb.Entry<Product>(info).State = EntityState.Deleted;
            try
            {
                _ProductDb.SaveChanges();
            }
            catch
            {
                HttpResponse response = this.Response;
                response.StatusCode = 400;
            }
        }

        public void EditInfo([FromBody] Product ProductInfo)
        {
            _ProductDb.Products.Add(ProductInfo);
            _ProductDb.Entry<Product>(ProductInfo).State = EntityState.Modified;
            try
            {
                _ProductDb.SaveChanges();
            }
            catch
            {
                HttpResponse response = this.Response;
                response.StatusCode = 400;
            }
        }

        public ActionResult<IEnumerable<Product>> GetAllProduct()
        {
            var Info = _ProductDb.Products.ToList();
            return Info;
        }
    }
}
