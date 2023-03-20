using Microsoft.AspNetCore.Mvc;

namespace WebStore.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
