using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestWebApi.Models
{
    public class ProductModel
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        [Required]
        [Column(TypeName ="decimal(10,2)")]
        public decimal? Price { get; set; }
        [MaxLength(200)]
        public string ImagesUrl { get; set;}
        public float stock { get; set; }
        public DateTime DateRegistration { get; set; }
        public int CategoryId { get; set; }
        public CategoryModel? Category { get; set; }
    }
}
