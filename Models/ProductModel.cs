using System.ComponentModel.DataAnnotations;

namespace TestWebApi.Models
{
    public class ProductModel
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public string ImagesUrl { get; set;}
        public float stock { get; set; }
        public DateTime DateRegistration { get; set; }
    }
}
