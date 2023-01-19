using JuanMVC.Helpers;
using JuanMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JuanMVC.Areas.Manage.Controllers
{
    [Area("Manage")]
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
            List<Product> products=_context.Products.Include(x=>x.ProductImages).ToList();
            return View(products);
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
            if (!ModelState.IsValid) return View(product);

            if(product.PosterImgFile== null)
            {
                ModelState.AddModelError("PosterImgFile", "Sekil yuklemeden product yarada bilmersiz!");
            }
            else
            {
                ProductImage posterImage = new ProductImage
                {
                    Product = product,
                    ImageUrl = FileManager.SaveFile(_env.WebRootPath, "uploads/productimages", product.PosterImgFile),
                    IsPoster = true
                };
                _context.ProductImages.Add(posterImage);
            }
            if (product.ProductImageFiles== null)
            {
                ModelState.AddModelError("ProductImageFiles", "Sekil yuklemeden product yarada bilmersiz!");
            }
            else{
                foreach (var productImage in product.ProductImageFiles)
                {
                    ProductImage productImg = new ProductImage
                    {
                        Product= product,
                        ImageUrl=FileManager.SaveFile(_env.WebRootPath, "uploads/productimages", productImage),
                        IsPoster=false
                    };
					_context.ProductImages.Add(productImg);
				}
			}
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            Product product = _context.Products.Include(x => x.ProductImages).FirstOrDefault(x => x.Id == id);
            if (product == null) return NotFound();
            return View(product);
        }
        [HttpPost]
        public IActionResult Update(Product product)
        {
            Product existProduct=_context.Products.Include(x=>x.ProductImages).FirstOrDefault(x=>x.Id==product.Id);
            if (existProduct == null) return NotFound();
            if (!ModelState.IsValid) return View();
            if (product.ProductImageFiles== null && product.ProductImgIds == null)
            {
                ModelState.AddModelError("ProductImageFiles", "product sekilleri bos ola bilmez!");
                return View(existProduct);
            }
            if (product.ProductImgIds != null)
            {
                existProduct.ProductImages.RemoveAll(x => !product.ProductImgIds.Contains(x.Id) && x.IsPoster == false);
            }
            else
            {
                existProduct.ProductImages.RemoveAll(x=>x.IsPoster == false);
            }
            if (product.PosterImgFile == null)
            {
                ModelState.AddModelError("PosterImgFile", "Sekil yuklemeden product yarada bilmersiz!");
            } 
            else
            {
                FileManager.DeleteFile(_env.WebRootPath, "uploads/productimages", 
                existProduct.ProductImages.FirstOrDefault(x=>x.IsPoster==true).ImageUrl);
                ProductImage posterImage = new ProductImage
                {
                    Product = product,
                    ImageUrl = FileManager.SaveFile(_env.WebRootPath, "uploads/productimages", product.PosterImgFile),
                    IsPoster = true
                };
                existProduct.ProductImages.FirstOrDefault(x => x.IsPoster == true).ImageUrl = posterImage.ImageUrl;
            }
            if (product.ProductImageFiles != null)
            {
                foreach (var productImageFile in product.ProductImageFiles)
                {
                //    FileManager.DeleteFile(_env.WebRootPath, "uploads/productimages",
                //existProduct.ProductImages.FirstOrDefault(x => x.IsPoster == false).ImageUrl);
                    ProductImage productImg = new ProductImage
                    {
                        Product = product,
                        ImageUrl = FileManager.SaveFile(_env.WebRootPath, "uploads/productimages", productImageFile),
                        IsPoster = false
                    };
                    existProduct.ProductImages.Add(productImg);
                }
            }
            existProduct.Name= product.Name;
            existProduct.Title = product.Title;
            existProduct.CostPrice = product.CostPrice;
            existProduct.SalePrice = product.SalePrice;
            existProduct.Discount = product.Discount;
            existProduct.IsAvaible = product.IsAvaible;
            existProduct.Description= product.Description;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Product product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (product == null) return NotFound();
            
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
