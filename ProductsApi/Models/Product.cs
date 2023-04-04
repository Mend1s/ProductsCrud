namespace ProductsApi.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ProductCategory Category { get; set; }
    }

    public enum ProductCategory
    {
        Food = 0,
        Convenience = 1,
        Commodities = 2,
        Durables = 3,
        Digital = 4
    }
}
