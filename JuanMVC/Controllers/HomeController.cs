using JuanMVC.Models;
using JuanMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JuanMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly JuanDb _context;
        public HomeController(JuanDb context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel
            {
                Sliders = _context.Sliders.ToList(),
                BannerProducts = _context.BannerProducts.ToList(),
                Products = _context.Products.Include(x=>x.ProductImages).ToList(),
                BannerStatics = _context.BannerStatics.ToList(),
            };
            return View(homeViewModel);
        }

    }
}