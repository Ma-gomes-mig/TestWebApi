using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace TestWebApi.Models
{
    public class CategoryModel
    {
        public CategoryModel()
        {
            Products = new Collection<ProductModel>();
        }
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }
        [Required]
        [MaxLength(200)]
        public string? ImagesUrl  { get; set; }
        public ICollection<ProductModel>? Products { get; set; }
    }
}
