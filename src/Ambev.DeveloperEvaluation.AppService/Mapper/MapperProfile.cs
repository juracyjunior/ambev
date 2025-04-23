using Ambev.DeveloperEvaluation.AppService.Command;
using Ambev.DeveloperEvaluation.AppService.Result;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.AppService.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Branch, BranchResult>();
            CreateMap<Customer, CustomerResult>();
            CreateMap<OrderItem, GetOrderItemResult>();
            CreateMap<Order, GetOrderResult>();
            CreateMap<Product, ProductResult>();

            CreateMap<CreateOrderCommand, Order>();
            CreateMap<CreateOrderItemCommand, OrderItem>();

            CreateMap<OrderItem, CreateOrderItemResult>();
            CreateMap<Order, CreateOrderResult>();

            CreateMap<UpdateOrderCommand, Order>();
            CreateMap<UpdateOrderItemCommand, OrderItem>();

            CreateMap<OrderItem, UpdateOrderItemResult>();
            CreateMap<Order, UpdateOrderResult>();
        }
    }
}
