using BusinessObject;
using DataAccess;

namespace Repositories
{
    public interface IProductRepository
    {
        void Save(ProductDTO product);
        Product GetProductById(int id);
        void DeleteProduct(Product product);
        void UpdateProduct(Product product);
        List<Category> GetCategories();
        List<Product> GetProducts();
    }
}