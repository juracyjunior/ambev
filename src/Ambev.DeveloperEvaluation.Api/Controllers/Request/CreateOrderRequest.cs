using Ambev.DeveloperEvaluation.Api.Controllers.Response;

namespace Ambev.DeveloperEvaluation.Api.Controllers.Request
{
    public class CreateOrderRequest
    {
        public DateTime SaleDate { get; set; }
        public Guid IdCustomer { get; set; }
        public Guid IdBranch { get; set; }
        public IList<CreateOrderItemRequest> Items { get; set; }
    }
}
