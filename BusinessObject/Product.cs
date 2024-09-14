using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        [Required]
        public string ProductName {get; set;}
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int UnitsInStock { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        public Category Categories { get; set; }
    }
}