using JuanMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace JuanMVC.Areas.Manage.Controllers
{
    public class ProductController : Controller
    {
        private readonly JuanDb _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(JuanDb context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (product == null) return NotFound();
            if (!ModelState.IsValid) return View();

            if(product.PosterImgFile== null)
            {
                ModelState.AddModelError("PosterImgFile", "Sekil yuklemeden product yarada bilmersiz!");
            }
            else
            {
                
            }
            if (product.ProductImageFiles== null)
            {
                ModelState.AddModelError("ProductImageFiles", "Sekil yuklemeden product yarada bilmersiz!");
            }
            else{
                foreach (ProductImage productImage in product.ProductImageFiles)
                {

                }
            }
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
