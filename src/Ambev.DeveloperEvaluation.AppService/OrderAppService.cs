using Ambev.DeveloperEvaluation.AppService.Command;
using Ambev.DeveloperEvaluation.AppService.Interface;
using Ambev.DeveloperEvaluation.AppService.Result;
using Ambev.DeveloperEvaluation.AppService.Validator;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.AppService
{
    public class OrderAppService(IOrderRepository orderRepository,
        IMapper mapper) : IOrderAppService
    {
        public async Task<GetOrderResult> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            if (id == Guid.Empty)
                throw new ValidationException("Order ID is required.");

            var order = await orderRepository.GetByIdAsync(id, cancellationToken);

            if (order == null)
                return null;

            return mapper.Map<GetOrderResult>(order);
        }

        public async Task<IEnumerable<GetOrderResult>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var orders = await orderRepository.GetAllAsync(cancellationToken);

            if (orders == null || !orders.Any())
                return null;

            var result = mapper.Map<IEnumerable<GetOrderResult>>(orders);

            return result;
        }

        public async Task<CreateOrderResult> CreateAsync(CreateOrderCommand command, CancellationToken cancellationToken = default)
        {
            var validator = new CreateOrderCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var entity = mapper.Map<Order>(command);

            CalculateDiscount(entity);

            var orderCreated = await orderRepository.CreateAsync(entity, cancellationToken);

            if (orderCreated == null)
                return null;

            return mapper.Map<CreateOrderResult>(orderCreated);
        }

        public async Task<UpdateOrderResult> UpdateAsync(UpdateOrderCommand command, CancellationToken cancellationToken = default)
        {
            var validator = new UpdateOrderCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            if (!await orderRepository.ExistsOrder(command.Id))
                return null;

            var entity = mapper.Map<Order>(command);

            CalculateDiscount(entity);

            foreach (var item in entity.Items)
            {
                item.Id = Guid.NewGuid();
                item.IdOrder = entity.Id;
            }

            var orderUpdated = await orderRepository.UpdateAsync(entity, cancellationToken);

            if (orderUpdated == null)
                return null;

            return mapper.Map<UpdateOrderResult>(orderUpdated);
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            if (id == Guid.Empty)
                throw new ValidationException("Order ID is required.");

            var order = await orderRepository.GetByIdAsync(id, cancellationToken);

            if (order == null)
                return false;
            
            await orderRepository.DeleteAsync(order, cancellationToken);

            return true;
        }

        private void CalculateDiscount(Order order)
        {
            foreach(var item in order.Items)
            {
                if (item.Quantity < 4 )
                {
                    item.Discount = 0;
                }
                else if (item.Quantity >= 4 && item.Quantity <= 9)
                {
                    item.Discount = 10;
                }
                else if (item.Quantity >= 10 && item.Quantity <= 20)
                {
                    item.Discount = 20;
                }
            }
        }
    }
}
