using Microsoft.EntityFrameworkCore;

namespace WebStore.Models
{
    public class WebStoreDbContext : DbContext
    {

        public WebStoreDbContext(DbContextOptions<WebStoreDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
