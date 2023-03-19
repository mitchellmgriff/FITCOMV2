using Moq;
using WebStore.Models;


namespace BethanysPieShopTests.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<IProductRepository> GetProductRepository()
        {
            var products = new List<Product>
            {
               new Product
                              {
                                  Name = "Mens Fitness Shirt",
                                  Price = 16.99M,
                                  Description = "Plain mens t shirt with high quality fabric",
                                  InStock = true,
                                  Category = Categories["Mens"],
                                  ImageUrl = "/images/MensFitnessShirt5.jpg",
                                  IsProductOfTheWeek = true
                              },
            new Product
            {
                Name = "Mens Fitness Shirt",
                Price = 36.99M,
                Description = "Plain mens shirt with high quality fabric",
                InStock = true,
                Category = Categories["Mens"],
                ImageUrl = "/images/MensFitnessShirt4.jpg",
                IsProductOfTheWeek = true
            },
            new Product
            {

                Name = "Mens Fitness Shirt",
                Price = 16.99M,
                Description = "Plain mens t shirt with high quality fabric",
                InStock = true,
                Category = Categories["Mens"],
                ImageUrl = "/images/MensFitnessShirt3.jpg",
                IsProductOfTheWeek = true
            },
            new Product
            {

                Name = "Womens Yoga Set",
                Price = 36.99M,
                Description = "Plain womens set with high quality fabric",
                InStock = true,
                Category = Categories["Womens"],
                ImageUrl = "/images/WomensSet.jpg",
                IsProductOfTheWeek = true
            },
            new Product
            {
                Name = "Womens Yoga Set",
                Price = 26.99M,
                Description = "Plain womens set with high quality material",
                InStock = true,
                Category = Categories["Womens"],
                ImageUrl = "/images/WomensSet2.jpg",
                IsProductOfTheWeek = true

            },
            new Product
            {

                Name = "Womens Yoga Set",
                Price = 26.99M,
                Description = "Plain womens set with high quality material",
                InStock = true,
                Category = Categories["Womens"],
                ImageUrl = "/images/WomensSet3.jpg",
                IsProductOfTheWeek = true


            }, new Product
            {

                Name = "Weights",
                Price = 26.99M,
                Description = "High quality weights in various sizes",
                InStock = true,
                Category = Categories["Accessories"],
                ImageUrl = "/images/WeightsPic2.jpg",
                IsProductOfTheWeek = true


            }, new Product
            {

                Name = "Weights",
                Price = 26.99M,
                Description = "High quality weights in various sizes",
                InStock = false,
                Category = Categories["Accessories"],
                ImageUrl = "/images/WeightsPic.jpg",
                IsProductOfTheWeek = true


            }
            };

            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository.Setup(repo => repo.AllProducts).Returns(products);
            mockProductRepository.Setup(repo => repo.ProductOfTheWeek).Returns(products.Where(p => p.IsProductOfTheWeek));
            mockProductRepository.Setup(repo => repo.GetProductById(It.IsAny<int>())).Returns(products[0]);
            return mockProductRepository;
        }

        public static Mock<ICategoryRepository> GetCategoryRepository()
        {
            var categories = new List<Category>
            {
                new Category()
                {
                    CategoryId = 1,
                    CategoryName = "Mens",
                    Description = "Lorem ipsum"
                },
                new Category()
                {
                    CategoryId = 2,
                    CategoryName = "Womens",
                    Description = "Lorem ipsum"
                },
                new Category()
                {
                    CategoryId = 3,
                    CategoryName = "Accessories",
                    Description = "Seasonal pies"
                }
            };

            var mockCategoryRepository = new Mock<ICategoryRepository>();
            mockCategoryRepository.Setup(repo => repo.AllCategories).Returns(categories);

            return mockCategoryRepository;
        }

        private static Dictionary<string, Category>? _categories;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (_categories == null)
                {
                    var genresList = new Category[]
                    {
                        new Category { CategoryName = "Mens" },
                        new Category { CategoryName = "Womens" },
                        new Category { CategoryName = "Accessories" }
                    };

                    _categories = new Dictionary<string, Category>();

                    foreach (var genre in genresList)
                    {
                        _categories.Add(genre.CategoryName, genre);
                    }
                }

                return _categories;
            }
        }
    }
}
