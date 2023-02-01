using AzureApi.Models;

namespace AzureApi.Interface
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrders(CancellationToken cancellationToken);
        Task<bool> AddOrders(Order order, CancellationToken cancellationToken);
        Task<List<Order>> GetOrdersById(int id, CancellationToken cancellationToken);
    }
}
