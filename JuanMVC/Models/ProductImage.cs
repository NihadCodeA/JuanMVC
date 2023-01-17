using System.ComponentModel.DataAnnotations.Schema;

namespace JuanMVC.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsPoster { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        public Product? Product { get; set; }

    }
}
