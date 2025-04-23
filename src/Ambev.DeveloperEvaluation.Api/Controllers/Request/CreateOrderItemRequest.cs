namespace Ambev.DeveloperEvaluation.Api.Controllers.Request
{
    public class CreateOrderItemRequest
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public Guid IdProduct { get; set; }
    }
}
