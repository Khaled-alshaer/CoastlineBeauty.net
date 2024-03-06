using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CoastlineBeauty.Models
{
    public class Product
    {
        [Key]
        [DisplayName("Product ID")]
        public int ProductId { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Size { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Gender { get; set; }

        [Required]
        [Range(1, 500)]
        public double Price { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
