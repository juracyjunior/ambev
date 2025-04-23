using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Order> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Order> CreateAsync(Order order, CancellationToken cancellationToken = default);
        Task<Order> UpdateAsync(Order order, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(Order order, CancellationToken cancellationToken = default);
    }
}
