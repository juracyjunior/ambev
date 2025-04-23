namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IList<OrderItem> Items { get; set; }
    }
}
