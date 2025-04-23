using Ambev.DeveloperEvaluation.AppService;
using Ambev.DeveloperEvaluation.AppService.Command;
using Ambev.DeveloperEvaluation.AppService.Result;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using Bogus;
using FluentValidation;
using FluentAssertions;
using NSubstitute;
using Ambev.DeveloperEvaluation.UnitTest.AppService.TestData;

namespace Ambev.DeveloperEvaluation.UnitTest.AppService
{
    public class OrderAppServiceTests
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly OrderAppService _orderAppService;

        public OrderAppServiceTests()
        {
            _orderRepository = Substitute.For<IOrderRepository>();
            _mapper = Substitute.For<IMapper>();
            _orderAppService = new OrderAppService(_orderRepository, _mapper);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnOrder_WhenOrderExists()
        {
            // Arrange
            var order = OrderTestData.Generate();
            var expectedResult = GetOrderResultTestData.Generate();

            _orderRepository.GetByIdAsync(order.Id, Arg.Any<CancellationToken>()).Returns(order);
            _mapper.Map<GetOrderResult>(order).Returns(expectedResult);

            // Act
            var result = await _orderAppService.GetByIdAsync(order.Id);

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldThrowValidationException_WhenIdIsEmpty()
        {
            // Act
            Func<Task> act = async () => await _orderAppService.GetByIdAsync(Guid.Empty);

            // Assert
            await act.Should().ThrowAsync<FluentValidation.ValidationException>().WithMessage("Order ID is required.");
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnOrders_WhenOrdersExist()
        {
            // Arrange
            var orders = OrderTestData.Generate(3);
            var expectedResults = GetOrderResultTestData.Generate(3);

            _orderRepository.GetAllAsync(Arg.Any<CancellationToken>()).Returns(orders);
            _mapper.Map<IEnumerable<GetOrderResult>>(orders).Returns(expectedResults);

            // Act
            var result = await _orderAppService.GetAllAsync();

            // Assert
            result.Should().BeEquivalentTo(expectedResults);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnCreatedOrder_WhenCommandIsValid()
        {
            // Arrange
            var command = CreateOrderCommandTestData.Generate();
            var order = OrderTestData.Generate();
            var createdOrder = OrderTestData.Generate();
            var expectedResult = CreateOrderResultTestData.Generate();

            _mapper.Map<Order>(command).Returns(order);
            _orderRepository.CreateAsync(order, Arg.Any<CancellationToken>()).Returns(createdOrder);
            _mapper.Map<CreateOrderResult>(createdOrder).Returns(expectedResult);

            // Act
            var result = await _orderAppService.CreateAsync(command);

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnUpdatedOrder_WhenCommandIsValid()
        {
            // Arrange
            var command = UpdateOrderCommandTestData.Generate();
            var order = OrderTestData.Generate();
            var updatedOrder = OrderTestData.Generate();
            var expectedResult = UpdateOrderResultTestData.Generate();

            _mapper.Map<Order>(command).Returns(order);
            _orderRepository.UpdateAsync(order, Arg.Any<CancellationToken>()).Returns(updatedOrder);
            _mapper.Map<UpdateOrderResult>(updatedOrder).Returns(expectedResult);

            // Act
            var result = await _orderAppService.UpdateAsync(command);

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnTrue_WhenOrderIsDeleted()
        {
            // Arrange
            var order = OrderTestData.Generate();

            _orderRepository.GetByIdAsync(order.Id, Arg.Any<CancellationToken>()).Returns(order);
            _orderRepository.DeleteAsync(order, Arg.Any<CancellationToken>()).Returns(true);

            // Act
            var result = await _orderAppService.DeleteAsync(order.Id);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnFalse_WhenOrderDoesNotExist()
        {
            // Arrange
            var orderId = Guid.NewGuid();

            _orderRepository.GetByIdAsync(orderId, Arg.Any<CancellationToken>()).Returns((Order)null);

            // Act
            var result = await _orderAppService.DeleteAsync(orderId);

            // Assert
            result.Should().BeFalse();
        }
    }
}
