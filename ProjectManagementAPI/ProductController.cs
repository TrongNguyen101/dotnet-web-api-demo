using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace ProductManagementAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductManagementAPI : ControllerBase
    {
        private IProductRepository repository = new ProductRepository();

        [HttpGet]
        public ActionResult<IList<Category>> GetProducts() => repository.GetProducts();

        [HttpPost]
        public IActionResult PostProduct(Product product)
        {
            repository.Save(product);
            return NoContent();
        }

        [HttpDelete("id")]
        public IActionResult DeleteProduct(int id)
        {
            var p = repository.GetProductById(id);
            if (p == null)
            {
                return NotFound();
            }
            repository.DeleteProduct(p);
            return NoContent();
        }

        [HttpPut("id")]
        public IActionResult PutProduct(int id, Product product)
        {
            var p = repository.GetProductById(id);
            if(p == null)
            {
                return NotFound();
            }
            repository.UpdateProduct(p);
            return NoContent();
        }
    }
}