namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get;     set; }
        public decimal Discount { get;  set; }
        public decimal TotalAmount => (UnitPrice * Quantity) - (UnitPrice * Quantity * Discount / 100);
        public Guid IdOrder { get; set; }
        public Order Order { get; set; }
        public Guid IdProduct { get; set; }
        public Product Product { get; set; }
    }
}
