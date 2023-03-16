using Microsoft.AspNetCore.Mvc;
using WebStore.Models;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public ActionResult List()
        {
            ProductListViewModel productsListViewModel = new ProductListViewModel(_productRepository.AllProducts, "Mens");
            return View(productsListViewModel);
        }

        public ActionResult Details(int id)
        {
            var product = _productRepository.GetProductById(id);
            if (product == null)
                return NotFound();
            return View(product);
        }
    }
}
