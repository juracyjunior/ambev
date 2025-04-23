namespace Ambev.DeveloperEvaluation.AppService.Command
{
    public class CreateOrderItemCommand
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public Guid IdProduct { get; set; }
    }
}
