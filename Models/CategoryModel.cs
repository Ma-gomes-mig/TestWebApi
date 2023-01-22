using System.ComponentModel.DataAnnotations;

namespace TestWebApi.Models
{
    public class CategoryModel
    {
        [Key]
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public string? ImagesUrl  { get; set; }
    }
}
