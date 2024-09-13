using BusinessObject;

namespace DataAccess
{
    public class CategoryDAO
    {
        #region Get Categories
        public static List<Category> GetCategories()
        {
            var listCategories = new List<Category>();
            try
            {
                using (var context = new MyDbContext())
                {
                    listCategories = context.Category.ToList();
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
            return listCategories;
        }
        #endregion
    }
}