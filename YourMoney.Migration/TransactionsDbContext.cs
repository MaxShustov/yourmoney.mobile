using Microsoft.EntityFrameworkCore;
using YourMoney.Standard.Core.Entities;
using YourMoney.Standard.Core.Utils;

namespace YourMoney.Standard.Core.Repositories
{
    public class TransactionsDbContext : DbContext
    {
        private readonly IPathProvider _pathProvider;

        public TransactionsDbContext(IPathProvider pathProvider)
        {
            _pathProvider = pathProvider;
        }

        public TransactionsDbContext()
        {
            
        }

        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var path = _pathProvider.GetDbPath();
            var path = string.Empty;

            optionsBuilder.UseSqlite($"Filename={path}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>()
                .HasKey(m => m.Id);
        }
    }
}