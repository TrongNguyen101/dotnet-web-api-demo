using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { set; get; }
        [Required]
        [StringLength(40)]
        public string ProductName { set; get; }
        [Required]
        public int CategoryId { set; get; }
        [Required]
        public int UnitsInStock { set; get; }
        [Required]
        public decimal UnitPrice { set; get; }
        [Required]
        public virtual Category Category { set; get; }
    }
}