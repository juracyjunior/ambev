using Ambev.DeveloperEvaluation.Api.Controllers.Request;
using Ambev.DeveloperEvaluation.Api.Validators;
using Ambev.DeveloperEvaluation.AppService.Command;
using Ambev.DeveloperEvaluation.AppService.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Ambev.DeveloperEvaluation.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly Serilog.ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IOrderAppService _orderAppService;

        public OrdersController(IMapper mapper, IOrderAppService orderAppService)
        {
            _logger = Log.Logger;
            _mapper = mapper;
            _orderAppService = orderAppService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            _logger.Information("Fetching all orders.");

            var orders = await _orderAppService.GetAllAsync(cancellationToken);

            if (orders == null || !orders.Any())
            {
                _logger.Warning("No orders found.");

                return NotFound(null);
            }

            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            _logger.Information($"Fetching one order {id}.");

            if (id == Guid.Empty)
            {
                _logger.Warning($"Order ID is required.");

                return BadRequest("Order ID is required.");
            }

            var order = await _orderAppService.GetByIdAsync(id, cancellationToken);

            if (order == null)
            {
                _logger.Warning($"No order found with ID {id}.");

                return NotFound(null);
            }

            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateOrderRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                _logger.Warning($"Order not created with invalid request.");

                return BadRequest(validationResult.Errors);
            }

            var command = _mapper.Map<CreateOrderCommand>(request);

            var result = await _orderAppService.CreateAsync(command, cancellationToken);

            return Created("", result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateOrderRequest request, CancellationToken cancellationToken)
        {
            if (id == Guid.Empty)
                return BadRequest("Order ID is required.");

            var validator = new UpdateOrderRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                _logger.Warning($"Order not updated with invalid request.");

                return BadRequest(validationResult.Errors);
            }

            var command = _mapper.Map<UpdateOrderCommand>(request);
            command.Id = id;

            var order = await _orderAppService.UpdateAsync(command, cancellationToken);

            if (order == null)
                return NotFound(null);
            
            return Ok(order);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            if (id == Guid.Empty)
            {
                _logger.Warning($"Order ID is required.");

                return BadRequest("Order ID is required.");
            }

            var result = await _orderAppService.DeleteAsync(id, cancellationToken);

            if (!result)
                return NotFound(null);

            return Ok();
        }
    }
}
