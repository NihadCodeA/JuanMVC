namespace JuanMVC.Models
{
    public class ProductImages
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsPoster { get; set; }
        public IFormFile? ImageFile { get; set; }
        public Product? Product { get; set; }

    }
}
