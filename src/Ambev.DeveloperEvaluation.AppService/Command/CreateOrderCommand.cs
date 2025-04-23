namespace Ambev.DeveloperEvaluation.AppService.Command
{
    public class CreateOrderCommand
    {
        public DateTime SaleDate { get; set; }
        public Guid IdCustomer { get; set; }
        public decimal TotalAmount { get; set; }
        public Guid IdBranch { get; set; }
        public IList<CreateOrderItemCommand> Items { get; set; }
        public bool IsCancelled { get; set; }
    }
}
