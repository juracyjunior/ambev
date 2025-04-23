namespace Ambev.DeveloperEvaluation.AppService.Result
{
    public class GetOrderResult
    {
        public Guid Id { get; set; }
        public Guid SaleNumber { get; set; }
        public DateTime SaleDate { get; set; }
        public CustomerResult Customer { get; set; }
        public decimal TotalAmount { get; set; }
        public BranchResult Branch { get; set; }
        public IList<GetOrderItemResult> Items { get; set; }
        public bool IsCancelled { get; set; }
    }
}
