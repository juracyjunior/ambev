using Ambev.DeveloperEvaluation.Api.Controllers.Request;
using Ambev.DeveloperEvaluation.AppService.Command;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Api.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            /*CreateMap<BranchResult, BranchResponse>();
            CreateMap<CustomerResult, CustomerResponse>();
            CreateMap<OrderItemResult, OrderItemResponse>();
            CreateMap<OrderResult, OrderResponse>();
            CreateMap<ProductResult, ProductResponse>();*/

            CreateMap<CreateOrderRequest, CreateOrderCommand>();
            CreateMap<CreateOrderItemRequest, CreateOrderItemCommand>();

            CreateMap<UpdateOrderRequest, UpdateOrderCommand>();
            CreateMap<UpdateOrderItemRequest, UpdateOrderItemCommand>();
        }
    }
}
