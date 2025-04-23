using Ambev.DeveloperEvaluation.AppService.Command;
using Ambev.DeveloperEvaluation.AppService.Result;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.AppService.Interface
{
    public interface IOrderAppService
    {
        Task<GetOrderResult> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<GetOrderResult>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<CreateOrderResult> CreateAsync(CreateOrderCommand command, CancellationToken cancellationToken = default);
        Task<UpdateOrderResult> UpdateAsync(UpdateOrderCommand order, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
