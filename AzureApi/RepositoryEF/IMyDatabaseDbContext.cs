using AzureApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AzureApi.RepositoryEF
{
    public interface IMyDatabaseDbContext: IDbContext
    {
        DbSet<Order> Orders { get; set; }
        
    }
}
