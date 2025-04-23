namespace Ambev.DeveloperEvaluation.Api.Controllers.Response
{
    public class OrderResponse
    {
        public Guid Id { get; set; }
        public Guid SaleNumber { get; set; }
        public DateTime SaleDate { get; set; }
        public CustomerResponse Customer { get; set; }
        public decimal TotalAmount { get; set; }
        public BranchResponse Branch { get; set; }
        public IList<OrderItemResponse> Items { get; set; }
        public bool IsCancelled { get; set; }
    }
}
