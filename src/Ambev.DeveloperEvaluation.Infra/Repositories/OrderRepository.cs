using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Ambev.DeveloperEvaluation.Infra.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;
        private readonly Serilog.ILogger _logger;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
            _logger = Log.Logger;
        }

        public async Task<List<Order>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            _logger.Information($"Fetching all orders.");

            return await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Branch)
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .ToListAsync(cancellationToken);
        }

        public async Task<Order> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            _logger.Information($"Fetching order with ID {id}.");

            return await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Branch)
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
        }

        public async Task<Order> CreateAsync(Order order, CancellationToken cancellationToken = default)
        {
            if (order == null)
                return null;

            _logger.Information("Creating a new order.");

            await _context.Orders.AddAsync(order, cancellationToken);
            
            await _context.SaveChangesAsync(cancellationToken);

            _logger.Information("New order created.");

            return order;
        }

        public async Task<Order> UpdateAsync(Order order, CancellationToken cancellationToken = default)
        {
            if (order == null)
                return null;

            _logger.Information($"Updating order with ID {order.Id}");

            var originalOrderItems = await _context.OrderItems
                .Where(o => o.IdOrder == order.Id)
                .ToListAsync();

            _context.OrderItems.RemoveRange(originalOrderItems); 
            
            _context.Orders.Update(order);

            foreach (var item in order.Items)
            {
                await _context.OrderItems.AddAsync(item);
            }

            await _context.SaveChangesAsync(cancellationToken);

            _logger.Information("Order updated.");

            return order;
        }

        public async Task<bool> DeleteAsync(Order order, CancellationToken cancellationToken = default)
        {
            if (order == null)
                return false;

            _logger.Information($"Deleting order with ID {order.Id}");

            _context.Orders.Remove(order);
            
            await _context.SaveChangesAsync(cancellationToken);

            _logger.Information("Order deleted.");

            return true;
        }
    }
}
