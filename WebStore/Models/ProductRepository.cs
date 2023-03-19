using Microsoft.EntityFrameworkCore;

namespace WebStore.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly WebStoreDbContext _webStoreDbContext;

        public ProductRepository(WebStoreDbContext webStoreDbContext)
        {
            _webStoreDbContext = webStoreDbContext;
        }

        public IEnumerable<Product> AllProducts
        {
            get
            {
                return _webStoreDbContext.Products.Include(c => c.Category);
            }
        }

        public IEnumerable<Product> ProductOfTheWeek
        {
            get
            {
                return _webStoreDbContext.Products.Include(c => c.Category).Where(p => p.IsProductOfTheWeek);
            }
        }

        public Product? GetProductById(int productId)
        {
            return _webStoreDbContext.Products.FirstOrDefault(p => p.ProductId == productId);
        }
        public IEnumerable<Product> SearchProducts(string searchQuery)
        {
            return _webStoreDbContext.Products.Where(p => p.Name.Contains(searchQuery));
        }
    }
}
