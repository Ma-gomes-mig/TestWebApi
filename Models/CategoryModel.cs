using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace TestWebApi.Models
{
    public class CategoryModel
    {
        public CategoryModel()
        {
            Product = new Collection<ProductModel>();
        }
        [Key]
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public string? ImagesUrl  { get; set; }
        public ICollection<ProductModel>? Products { get; set; }
    }
}
