namespace WebStore.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly WebStoreDbContext _webStoreDbContext;
        public CategoryRepository(WebStoreDbContext webStoreDbContext)
        {
            _webStoreDbContext = webStoreDbContext;
        }

        public IEnumerable<Category> AllCategories =>
            _webStoreDbContext.Categories.OrderBy(p => p.CategoryName);
    }
}
