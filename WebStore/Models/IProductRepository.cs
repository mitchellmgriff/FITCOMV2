namespace WebStore.Models
{
    public interface IProductRepository
    {

        IEnumerable<Product> AllProducts { get; }
        IEnumerable<Product> ProductOfTheWeek { get; }

        Product? GetProductById(int productId);
    }
}
