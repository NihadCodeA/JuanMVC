using System.ComponentModel.DataAnnotations.Schema;

namespace JuanMVC.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double CostPrice { get; set; }
        public double SalePrice { get; set; }
        public double Discount { get; set; }
        public bool IsAvaible { get; set; }

        [NotMapped]
        public IFormFile? PosterImgFile { get; set; }
        public List<ProductImage>? ProductImages { get; set; }
        [NotMapped]
        public List<IFormFile>? ProductImageFiles { get; set; }
    }
}
