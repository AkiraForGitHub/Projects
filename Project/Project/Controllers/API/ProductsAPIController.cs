using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Interface;
using Project.Models;

namespace Project.Controllers.API
{
    [Route("api/ProductAPI/{action}")]
    [ApiController]
    public class ProductsAPIController : ControllerBase
    {
        private readonly IProductFeatures _productFeatures;

        public ProductsAPIController(IProductFeatures productFeatures)
        {
            _productFeatures = productFeatures;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProduct()
        {
            return _productFeatures.GetAllProduct();
        }
        //新增
        [HttpPost]
        public void AddOnce([FromBody]Product ProductInfo)
        {
             _productFeatures.AddOnce(ProductInfo);
        }

        //修改
        [HttpPut]
        public void EditInfo([FromBody] Product ProductInfo)
        {
            _productFeatures.EditInfo(ProductInfo);
        }

        //刪除
        [HttpDelete]
        public void DeleteProduct([FromQuery(Name ="id")] int id)
        {
            _productFeatures.DeleteProduct(id);
        }
    }
}

