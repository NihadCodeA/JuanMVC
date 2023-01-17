using Microsoft.AspNetCore.Mvc;

namespace JuanMVC.Areas.Manage.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
