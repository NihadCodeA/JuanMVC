using JuanMVC.Helpers;
using JuanMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace JuanMVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class BannerStaticController : Controller
    {
            private readonly JuanDb _context;
            private readonly IWebHostEnvironment _env;
            public BannerStaticController(JuanDb context, IWebHostEnvironment env)
            {
                _context = context;
                _env = env;
            }
            public IActionResult Index()
            {
                List<BannerStatic> bannerStatics = _context.BannerStatics.ToList();
                return View(bannerStatics);
            }
            public IActionResult Create()
            {
                return View();
            }
            [HttpPost]
            public IActionResult Create(BannerStatic bannerStatic)
            {
                if (bannerStatic == null) return NotFound();
                if (!ModelState.IsValid) return View();
                if (bannerStatic.ImgformFile == null)
                {
                    ModelState.AddModelError("ImgformFile", "Sekil yuklenmese bannerProductyarada bilmersiz!");
                    return View();
                }
                else
                {
                bannerStatic.ImgUrl = FileManager.SaveFile(_env.WebRootPath, "uploads/bannerstatics", bannerStatic.ImgformFile);
                }
                _context.BannerStatics.Add(bannerStatic);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            [HttpGet]
            public IActionResult Update(int id)
            {
                BannerStatic bannerStatic = _context.BannerStatics.FirstOrDefault(s => s.Id == id);
                if (bannerStatic == null) return NotFound();
                return View(bannerStatic);
            }

            [HttpPost]
            public IActionResult Update(BannerStatic bannerStatic)
            {
            BannerStatic existBannerStatic = _context.BannerStatics.FirstOrDefault(x => x.Id == bannerStatic.Id);
                if (bannerStatic == null) return NotFound();
                if (!ModelState.IsValid) return View();
                if (bannerStatic.ImgformFile != null)
                {
                //FileManager.DeleteFile(_env.WebRootPath, "uploads/sliders", existslider.ImgUrl);
                existBannerStatic.ImgUrl = FileManager.SaveFile(_env.WebRootPath, "uploads/bannerproducts", bannerStatic.ImgformFile);
                }
            existBannerStatic.BannerSubtitle = bannerStatic.BannerSubtitle;
            existBannerStatic.BannerTitle1 = bannerStatic.BannerTitle1;
            existBannerStatic.BannerTitle2 = bannerStatic.BannerTitle2;
                _context.SaveChanges();
                return RedirectToAction("Index");

            }

            public IActionResult Delete(int id)
            {
            BannerStatic bannerStatic = _context.BannerStatics.FirstOrDefault(s => s.Id == id);

            if (bannerStatic == null) return NotFound();
                FileManager.DeleteFile(_env.WebRootPath, "uploads/bannerstatics", bannerStatic.ImgUrl);
                _context.BannerStatics.Remove(bannerStatic);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
}
