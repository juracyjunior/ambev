namespace Ambev.DeveloperEvaluation.AppService.Result
{
    public class GetOrderItemResult
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public ProductResult Product { get; set; }
    }
}
