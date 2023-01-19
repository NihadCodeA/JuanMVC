using System.ComponentModel.DataAnnotations.Schema;

namespace JuanMVC.Models
{
    public class BannerStatic
    {
        public int Id { get; set; } 

        public string BannerSubtitle{ get; set; }
        public string BannerTitle1 { get; set; }
        public string BannerTitle2 { get; set; }
        public string? ImgUrl { get; set; }
        [NotMapped]
        public IFormFile? ImgformFile { get; set; }
    }
}
