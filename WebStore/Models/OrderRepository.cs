namespace WebStore.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly WebStoreDbContext _webStoreDbContext;
        private readonly IShoppingCart _shoppingCart;

        public OrderRepository(WebStoreDbContext webStoreDbContext, IShoppingCart shoppingCart)
        {
            _webStoreDbContext = webStoreDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            List<ShoppingCartItem>? shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            order.OrderDetails = new List<OrderDetail>();

            foreach (ShoppingCartItem? shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    ProductId = shoppingCartItem.Product.ProductId,
                    Price = shoppingCartItem.Product.ProductId
                };

                order.OrderDetails.Add(orderDetail);
            }

            _webStoreDbContext.Orders.Add(order);

            _webStoreDbContext.SaveChanges();
        }
    }
}
