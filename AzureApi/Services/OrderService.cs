using AzureApi.Interface;
using AzureApi.Models;
using AzureApi.RepositoryEF;
using Microsoft.EntityFrameworkCore;

namespace AzureApi.Services
{
    public class OrderService:IOrderService
    {
        private readonly IMyDatabaseDbContext _dbContext;
        public OrderService(IMyDatabaseDbContext dbContext) 
        { 
            _dbContext = dbContext;
        }

        public async Task<bool> AddOrders(Order order, CancellationToken cancellationToken)
        {
            await this._dbContext.Orders.AddAsync(order);
            return await this._dbContext.SaveChangesAsync(cancellationToken) != 0;
        }

        public async Task<List<Order>> GetOrders(CancellationToken cancellationToken)
        {
            return await _dbContext.Orders.ToListAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<List<Order>> GetOrdersById(int id, CancellationToken cancellationToken)
        {
            return await _dbContext.Orders.Where(x => x.Id == id).ToListAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
