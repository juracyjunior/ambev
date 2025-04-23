namespace Ambev.DeveloperEvaluation.AppService.Result
{
    public class UpdateOrderResult
    {
        public Guid Id { get; set; }
        public Guid SaleNumber { get; set; }
        public DateTime SaleDate { get; set; }
        public Guid IdCustomer { get; set; }
        public decimal TotalAmount { get; set; }
        public Guid IdBranch { get; set; }
        public IList<UpdateOrderItemResult> Items { get; set; }
        public bool IsCancelled { get; set; }
    }
}
