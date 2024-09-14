using BusinessObject;
using DataAccess;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        public void DeleteProduct(Product product) => ProductDAO.DeleteProduct(product);

        public List<Category> GetCategories() => CategoryDAO.GetCategories();

        public Product GetProductById(int id) => ProductDAO.FindProductById(id);

        public List<Product> GetProducts() => ProductDAO.GetProducts();

        public void Save(ProductDTO product) => ProductDAO.SaveProduct(product);

        public void UpdateProduct(Product product) => ProductDAO.UpdateProduct(product);
    }
}