namespace WebStore.Models
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
