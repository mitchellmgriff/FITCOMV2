using BethanysPieShopTests.Mocks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Controllers;
using WebStore.ViewModels;

namespace FITCOMTestProject.Controllers
{
    public class ProductControllerTests
    {
        [Fact]
        public void List_EmptyCategory_ReturnsAllProducts()
        {
            //arrange
            var mockProductRepository = RepositoryMocks.GetProductRepository();
            var mockCategoryRepository = RepositoryMocks.GetCategoryRepository();

            var productController = new ProductController(mockProductRepository.Object, mockCategoryRepository.Object);
            //act

            var result = productController.List("");

            //assert

            var viewResult = Assert.IsType<ViewResult>(result);
            var productListViewModel = Assert.IsAssignableFrom<ProductListViewModel>
                (viewResult.ViewData.Model);
            Assert.Equal(8, productListViewModel.Products.Count());

        }
    }
}
