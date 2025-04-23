namespace Ambev.DeveloperEvaluation.AppService.Result
{
    public class CreateOrderItemResult
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public Guid IdProduct { get; set; }
    }
}
