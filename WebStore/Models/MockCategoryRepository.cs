namespace WebStore.Models
{
    public class MockCategoryRepository : ICategoryRepository
    {

        public IEnumerable<Category> AllCategories =>
            new List<Category>
            {
                new Category { CategoryId = 1, CategoryName = "Mens", Description = "All mens clothes" },
                new Category { CategoryId = 2, CategoryName = "Womens", Description = "All womens clothes" },
                new Category { CategoryId = 3, CategoryName = "Accessories", Description = "Watches, necklaces, hats etc." }
            };
    }
}