
using Microsoft.EntityFrameworkCore;

namespace WebStore.Models
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly WebStoreDbContext _webStoreDbContext;

        public string? ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = default!;

        private ShoppingCart(WebStoreDbContext webStoreDbContext)
        {
            _webStoreDbContext = webStoreDbContext;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

            WebStoreDbContext context = services.GetService<WebStoreDbContext>() ?? throw new Exception("Error initializing");

            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();

            session?.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Product product)
        {
            var shoppingCartItem =
                    _webStoreDbContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Product.ProductId == product.ProductId && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Product = product,
                    Amount = 1
                };

                _webStoreDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _webStoreDbContext.SaveChanges();
        }

        public int RemoveFromCart(Product product)
        {
            var shoppingCartItem =
                    _webStoreDbContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Product.ProductId == product.ProductId && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _webStoreDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _webStoreDbContext.SaveChanges();

            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??=
                       _webStoreDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                           .Include(s => s.Product)
                           .ToList();
        }

        public void ClearCart()
        {
            var cartItems = _webStoreDbContext
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _webStoreDbContext.ShoppingCartItems.RemoveRange(cartItems);

            _webStoreDbContext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _webStoreDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Product.Price * c.Amount).Sum();
            return total;
        }
    }
}
