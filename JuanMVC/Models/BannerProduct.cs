using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JuanMVC.Models
{
    public class BannerProduct
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 25)]
        public string Title { get; set; }
        [StringLength(maximumLength: 50)]
        public string Description { get; set; }
        public string? ImgUrl { get; set; }
        [NotMapped]
        public IFormFile? ImgFile { get; set; }
    }
}
