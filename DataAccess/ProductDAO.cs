using BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ProductDAO
    {
        #region Get Products
        public static List<Product> GetProducts()
        {
            var listProducts = new List<Product>();
            try
            {
                using var context = new MyDbContext();
                listProducts = context.Product.ToList();
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
            return listProducts;
        }
        #endregion

        #region Find Product By Id
        public static Product FindProductById(int id)
        {
            Product product;
            try
            {
                using(var context = new MyDbContext())
                {
                    product = context.Product.FirstOrDefault(p => p.ProductId == id);
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
            return product;
        }
        #endregion
        
        #region Save product
        public static void SaveProduct(Product product)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Product.Add(product);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Update Product
        public static void UpdateProduct(Product product)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Entry<Product>(product).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
        #endregion
        
        #region  Delete Product
        public static void DeleteProduct(Product product)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var p = context.Product.FirstOrDefault(x => x.ProductId == product.ProductId);
                    context.Product.Remove(p);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}