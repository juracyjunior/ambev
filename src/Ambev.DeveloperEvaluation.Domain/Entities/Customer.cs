namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IList<Order> Orders { get; set; }
    }
}
