using BusinessObject;

namespace Repositories
{
    public interface IProductRepository
    {
        void Save(Product product);
        Product GetProductById(int id);
        void DeleteProduct(Product product);
        void UpdateProduct(Product product);
        List<Category> GetCategories();
        List<Category> GetProducts();
    }
}