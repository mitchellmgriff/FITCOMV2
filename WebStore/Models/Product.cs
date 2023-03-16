namespace WebStore.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsProductOfTheWeek { get; set; }
        public string? ImageUrl { get; set; }

        public bool InStock { get; set; }
        public decimal Price { get; set; }



        public int CategoryId { get; set; }
        public Category Category { get; set; } = default!;
    }
}
