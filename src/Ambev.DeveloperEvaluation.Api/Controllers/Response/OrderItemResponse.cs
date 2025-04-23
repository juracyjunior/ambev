using Ambev.DeveloperEvaluation.AppService.Result;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Api.Controllers.Response
{
    public class OrderItemResponse
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public ProductResult Product { get; set; }
    }
}
