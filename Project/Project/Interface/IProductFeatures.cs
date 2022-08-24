using Microsoft.AspNetCore.Mvc;
using Project.Models;

namespace Project.Interface
{
    public interface IProductFeatures
    {
        ActionResult<IEnumerable<Product>> GetAllProduct();
        void AddOnce([FromBody] Product ProductInfo);
        void EditInfo([FromBody] Product ProductInfo);
        void DeleteProduct([FromQuery(Name = "id")] int id);
    }
}
