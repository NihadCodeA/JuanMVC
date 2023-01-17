using JuanMVC.Helpers;
using JuanMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace JuanMVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class SliderController : Controller
    {
        private readonly JuanDb _context;
        private readonly IWebHostEnvironment _env;
        public SliderController(JuanDb context,IWebHostEnvironment env) {
            _context = context;
            _env = env;
         }
        public IActionResult Index()
        {
            List<Slider> sliders = _context.Sliders.ToList();
            return View(sliders);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Slider slider)
        {
            if(slider == null) return NotFound();
            if (!ModelState.IsValid) return View();
            if (slider.ImgFile == null)
            {
                ModelState.AddModelError("ImgFile", "Sekil yuklenmese slider yarada bilmersiz!");
                return View();
            }
            else
            {
                slider.ImgUrl = FileManager.SaveFile(_env.WebRootPath,"uploads/sliders",slider.ImgFile);
            }
            _context.Sliders.Add(slider);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Slider slider = _context.Sliders.FirstOrDefault(s => s.Id == id);
            if (slider == null) return NotFound();
            return View(slider);
        }

       [HttpPost]
        public IActionResult Update(Slider slider)
        {
            Slider existslider = _context.Sliders.FirstOrDefault(s =>s.Id==slider.Id);
            if (slider == null) return NotFound();
            if (!ModelState.IsValid) return View();
            if (slider.ImgFile != null)
            {
                //FileManager.DeleteFile(_env.WebRootPath, "uploads/sliders", existslider.ImgUrl);
                existslider.ImgUrl =FileManager.SaveFile(_env.WebRootPath, "uploads/sliders", slider.ImgFile);
            }
            existslider.Title = slider.Title;
            existslider.Description = slider.Description;
            existslider.TagName= slider.TagName;
            existslider.RedirectText = slider.RedirectText;
            existslider.RedirectUrl = slider.RedirectUrl;
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult Delete(int id)
        {
            Slider slider = _context.Sliders.FirstOrDefault(s => s.Id == id);
            if (slider == null) return NotFound();
            //string name = slider.Id + slider.ImgFile.FileName; 
            //string path = Path.Combine(_env.WebRootPath, "uploads/sliders", name);
            //FileInfo fileInfo = new FileInfo(Path.Combine(_env.WebRootPath, "uploads/sliders",slider.ImgUrl));
            //if (fileInfo.Exists)
            //{
            //    fileInfo.Delete();
            //}
            _context.Sliders.Remove(slider);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
