namespace WebStore.Models
{
    public class DbInitializer
    {

        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            WebStoreDbContext context = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<WebStoreDbContext>();

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(c => c.Value));
            }

            if (!context.Products.Any())
            {
                context.AddRange
                (
                              new Product
                              {
                                  Name = "Mens T Shirt",
                                  Price = 16.99M,
                                  Description = "Plain mens t shirt with high quality fabric",
                                  InStock = true,
                                  Category = Categories["Mens"],
                                  ImageUrl = "/images/mensTshirt1.jpg",
                                  IsProductOfTheWeek = true
                              },
            new Product
            {
                Name = "Mens Jacket",
                Price = 36.99M,
                Description = "Plain mens jacket with high quality fabric",
                InStock = true,
                Category = Categories["Mens"],
                ImageUrl = "/images/mensJacket.jpg",
                IsProductOfTheWeek = true
            },
            new Product
            {

                Name = "Womens T Shirt",
                Price = 16.99M,
                Description = "Plain womens t shirt with high quality fabric",
                InStock = true,
                Category = Categories["Womens"],
                ImageUrl = "/images/womensTshirt1.jpg",
                IsProductOfTheWeek = true
            },
            new Product
            {

                Name = "Womens Jacket",
                Price = 36.99M,
                Description = "Plain womens jacket with high quality fabric",
                InStock = true,
                Category = Categories["Womens"],
                ImageUrl = "/images/womensJacket.jpg",
                IsProductOfTheWeek = true
            },
            new Product
            {
                Name = "Mens ring",
                Price = 26.99M,
                Description = "Plain mens ring with high quality material",
                InStock = true,
                Category = Categories["Accessories"],
                ImageUrl = "/images/mensRing.jpg",
                IsProductOfTheWeek = true

            },
            new Product
            {

                Name = "Womens ring",
                Price = 26.99M,
                Description = "Plain womens ring with high quality material",
                InStock = true,
                Category = Categories["Accessories"],
                ImageUrl = "/images/womensRing1.jpg",
                IsProductOfTheWeek = true


            });
                context.SaveChanges();
            }


        }

        private static Dictionary<string, Category>? categories;

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var genresList = new Category[]
                    {
                        new Category { CategoryName = "Mens" },
                        new Category { CategoryName = "Womens" },
                        new Category { CategoryName = "Accessories" }
                    };

                    categories = new Dictionary<string, Category>();

                    foreach (Category genre in genresList)
                    {
                        categories.Add(genre.CategoryName, genre);
                    }
                }

                return categories;
            }
        }
    }
}






