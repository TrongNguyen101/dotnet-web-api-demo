using BusinessObject;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace ProductManagementAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductManagementAPI : ControllerBase
    {
        private IProductRepository repository;
        public ProductManagementAPI(IProductRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<IList<Product>> GetProducts() => repository.GetProducts();

        [HttpPost]
        public IActionResult PostProduct(ProductDTO product)
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
        public IActionResult PutProduct(int id, ProductDTO productDTO)
        {
            var p = repository.GetProductById(id);
            if(p == null)
            {
                return NotFound();
            }
            p.ProductName = productDTO.ProductName;
            p.CategoryId = productDTO.CategoryId;
            p.UnitPrice = productDTO.UnitPrice;
            p.UnitsInStock = productDTO.UnitsInStock;
            repository.UpdateProduct(p);
            return NoContent();
        }
    }
}