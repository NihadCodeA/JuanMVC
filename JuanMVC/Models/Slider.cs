using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JuanMVC.Models
{
    public class Slider
    {
        public int Id { get; set; }
        [StringLength(maximumLength:20)] 
        public string TagName { get; set; }
        [StringLength(maximumLength:30)] 
        public string Title { get; set; }
        [StringLength(maximumLength:150)] 
        public string Description { get; set; }
        public string RedirectText { get; set; }
        [StringLength(maximumLength:30)]
        public string RedirectUrl { get; set; }
        public string? ImgUrl { get; set; }
        [NotMapped]
        public IFormFile? ImgFile { get; set; }
    }
}
