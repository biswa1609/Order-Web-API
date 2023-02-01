namespace AzureApi.RepositoryEF
{
    public interface IDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
