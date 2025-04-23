using System.Text.Json.Serialization;

namespace Ambev.DeveloperEvaluation.Api.Controllers.Request
{
    public class UpdateOrderRequest
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public Guid SaleNumber { get; set; }
        public DateTime SaleDate { get; set; }
        public Guid IdCustomer { get; set; }
        public Guid IdBranch { get; set; }
        public IList<UpdateOrderItemRequest> Items { get; set; }
    }
}
