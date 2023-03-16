namespace WebStore.Models
{
    public class MockProductRepository : IProductRepository
    {

        private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();
        public IEnumerable<Product> AllProducts =>
            new List<Product>
            {
                new Product
                {
                    ProductId = 1,
                    Name = "Mens T Shirt",
                    Price = 16.99M,
                    Description = "Plain mens t shirt with high quality fabric",
                    InStock = true,
                    Category = _categoryRepository.AllCategories.ToList()[0],
                    ImageUrl = "/images/mensTshirt1.jpg",
                    IsProductOfTheWeek= false
                },
                new Product
                {
                    ProductId = 2,
                    Name = "Mens Jacket",
                    Price = 36.99M,
                    Description = "Plain mens jacket with high quality fabric",
                    InStock = true,
                    Category = _categoryRepository.AllCategories.ToList()[0],
                    ImageUrl = "/images/mensJacket.jpg",
                    IsProductOfTheWeek= true
                },
                new Product
                {
                    ProductId = 3,
                    Name = "Womens T Shirt",
                    Price = 16.99M,
                    Description = "Plain womens t shirt with high quality fabric",
                    InStock = true,
                    Category = _categoryRepository.AllCategories.ToList()[1],
                    ImageUrl = "/images/womensTshirt1.jpg",
                    IsProductOfTheWeek= false
                },
                new Product
                {
                    ProductId = 4,
                    Name = "Womens Jacket",
                    Price = 36.99M,
                    Description = "Plain womens jacket with high quality fabric",
                    InStock = true,
                    Category = _categoryRepository.AllCategories.ToList()[1],
                    ImageUrl = "/images/womensJacket.jpg",
                    IsProductOfTheWeek= true
                },
                new Product
                {
                    ProductId = 5,
                    Name = "Mens ring",
                    Price = 26.99M,
                    Description = "Plain mens ring with high quality material",
                    InStock = true,
                    Category = _categoryRepository.AllCategories.ToList()[2],
                    ImageUrl = "/images/mensRing.jpg",
                    IsProductOfTheWeek= true

                },
                new Product
                {
                    ProductId = 6,
                    Name = "Womens ring",
                    Price = 26.99M,
                    Description = "Plain womens ring with high quality material",
                    InStock = true,
                    Category = _categoryRepository.AllCategories.ToList()[2],
                    ImageUrl = "/images/womensRing1.jpg",
                    IsProductOfTheWeek= true
                }

            };

        public IEnumerable<Product> ProductOfTheWeek
        {
            get
            {
                return AllProducts.Where(p => p.IsProductOfTheWeek);
            }
        }

        public Product? GetProductById(int productId) => AllProducts.FirstOrDefault(p => p.ProductId == productId);

        public IEnumerable<Product> SearchProduct(string searchQuery)
        {
            throw new NotImplementedException();
        }
    }
}
