using JuanMVC.Models;

namespace JuanMVC.ViewModels
{
    public class HomeViewModel
    {
        public List<Slider> Sliders = new List<Slider>();
        public List<BannerProduct> BannerProducts = new List<BannerProduct>();
        public List<Product> Products = new List<Product>();
        public List<BannerStatic> BannerStatics = new List<BannerStatic>();
    }
}
