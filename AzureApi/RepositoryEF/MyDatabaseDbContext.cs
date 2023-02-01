using AzureApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AzureApi.RepositoryEF
{
    public class MyDatabaseDbContext : DbContext, IMyDatabaseDbContext
    {
        public MyDatabaseDbContext(DbContextOptions<MyDatabaseDbContext> options) : base(options) 
        {
            
        }
        public DbSet<Order> Orders { get; set ; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if(modelBuilder == null)
            {
                throw new AbandonedMutexException(nameof(modelBuilder));
            }
            this.ConfigurePrimaryKey(modelBuilder);
        }

        private void ConfigurePrimaryKey(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasKey(enity=> enity.Id);
        }
    }
}
