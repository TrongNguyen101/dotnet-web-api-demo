using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject
{
    public class Category 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int  CategoryId { get; set; }
        [Required]
        [StringLength(40)]
        public required string CategoryName { get; set; }
        public required ICollection<Product> Products { get; set; }
    }
}