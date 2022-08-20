using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Controllers.API
{
    [Route("api/ProductAPI/{action}")]
    [ApiController]
    public class ProductsAPIController : ControllerBase
    {
        private readonly ProductContext _ProductDb;

        public ProductsAPIController(ProductContext productDb)
        {
            _ProductDb = productDb;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProduct()
        {
            var Info = _ProductDb.Products.ToList();
            return Info;
        }
        [HttpPost]
        public void AddOnce([FromBody]Product ProductInfo)
        {
            _ProductDb.Products.Add(ProductInfo);
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

        //新增
        [HttpPost]
        public void EditInfo([FromBody] Product ProductInfo)
        {
            _ProductDb.Products.Add(ProductInfo);
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
        [HttpDelete]
        public void DeleteProduct([FromQuery(Name ="id")] int id)
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
    }
}

