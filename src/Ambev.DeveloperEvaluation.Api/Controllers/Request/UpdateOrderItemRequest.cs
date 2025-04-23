namespace Ambev.DeveloperEvaluation.Api.Controllers.Request
{
    public class UpdateOrderItemRequest
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public Guid IdProduct { get; set; }
    }
}
