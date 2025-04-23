namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid SaleNumber { get; set; }
        public DateTime SaleDate { get; set; }
        public Guid IdCustomer { get; set; }
        public Customer Customer { get; set; }
        public decimal TotalAmount => Items.Sum(i => i.TotalAmount);
        public Guid IdBranch { get; set; }
        public Branch Branch { get; set; }
        public IList<OrderItem> Items { get; set; }
        public bool IsCancelled { get; set; }

        public Order()
        {
            Items = new List<OrderItem>();
        }
    }
}
