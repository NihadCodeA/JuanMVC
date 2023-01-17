using JuanMVC.Helpers;
using JuanMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace JuanMVC.Areas.Manage.Controllers
{
    [Area("Manage")]

    public class BannerProductController : Controller
    {
        private readonly JuanDb _context;
        private readonly IWebHostEnvironment _env;
        public BannerProductController(JuanDb context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            List<BannerProduct> bannerProducts = _context.BannerProducts.ToList();
            return View(bannerProducts);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(BannerProduct bannerProduct)
        {
            if (bannerProduct== null) return NotFound();
            if (!ModelState.IsValid) return View();
            if (bannerProduct.ImgFile == null)
            {
                ModelState.AddModelError("ImgFile", "Sekil yuklenmese bannerProductyarada bilmersiz!");
                return View();
            }
            else
            {
                bannerProduct.ImgUrl = FileManager.SaveFile(_env.WebRootPath, "uploads/bannerproducts", bannerProduct.ImgFile);
            }
            _context.BannerProducts.Add(bannerProduct);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            BannerProduct bannerProduct= _context.BannerProducts.FirstOrDefault(s => s.Id == id);
            if (bannerProduct== null) return NotFound();
            return View(bannerProduct);
        }

        [HttpPost]
        public IActionResult Update(BannerProduct bannerProduct)
        {
            BannerProduct existBannerProduct= _context.BannerProducts.FirstOrDefault(s => s.Id == bannerProduct.Id);
            if (bannerProduct== null) return NotFound();
            if (!ModelState.IsValid) return View();
            if (bannerProduct.ImgFile != null)
            {
                //FileManager.DeleteFile(_env.WebRootPath, "uploads/sliders", existslider.ImgUrl);
                existBannerProduct.ImgUrl = FileManager.SaveFile(_env.WebRootPath, "uploads/bannerproducts", bannerProduct.ImgFile);
            }
            existBannerProduct.Title = bannerProduct.Title;
            existBannerProduct.Description = bannerProduct.Description;
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult Delete(int id)
        {
            BannerProduct bannerProduct= _context.BannerProducts.FirstOrDefault(s => s.Id == id);
            if (bannerProduct== null) return NotFound();
            //string name = slider.Id + slider.ImgFile.FileName; 
            //string path = Path.Combine(_env.WebRootPath, "uploads/sliders", name);
            //FileInfo fileInfo = new FileInfo(Path.Combine(_env.WebRootPath, "uploads/sliders",slider.ImgUrl));
            //if (fileInfo.Exists)
            //{
            //    fileInfo.Delete();
            //}
            _context.BannerProducts.Remove(bannerProduct);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
