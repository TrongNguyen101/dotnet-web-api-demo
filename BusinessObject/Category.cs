using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject
{
    public class Category 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int  CategoryId { set; get; }
        [Required]
        [StringLength(40)]
        public string CategoryName { set; get; }
        public virtual ICollection<Product> Product { set; get; }
    }
}