using BusinessObject;
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
        public IActionResult PostProduct(ProductDTO productDTO)
        {
            Product product = new Product()
            {
                ProductName = productDTO.ProductName,
                CategoryId = productDTO.CategoryId,
                UnitsInStock = productDTO.UnitsInStock,
                UnitPrice = productDTO.UnitPrice,
            };
            repository.Save(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
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

        [HttpPut("{id}")]
        public IActionResult PutProduct(int id, ProductDTO productDTO)
        {
            var product = repository.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            product.ProductName = productDTO.ProductName;
            product.CategoryId = productDTO.CategoryId;
            product.UnitPrice = productDTO.UnitPrice;
            product.UnitsInStock = productDTO.UnitsInStock;
            repository.UpdateProduct(product);
            return NoContent();
        }
    }
}