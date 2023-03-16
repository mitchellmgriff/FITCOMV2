using Microsoft.AspNetCore.Mvc;
using WebStore.Models;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;

        public HomeController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {

            var productOfTheWeek = _productRepository.ProductOfTheWeek;
            var homeViewModel = new HomeViewModel(productOfTheWeek);
            return View(homeViewModel);
        }


    }
}