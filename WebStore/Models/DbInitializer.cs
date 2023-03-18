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






