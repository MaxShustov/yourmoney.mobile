using Microsoft.EntityFrameworkCore;
using YourMoney.Standard.Core.Api.Models;
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

        public DbSet<TransactionModel> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var path = _pathProvider.GetDbPath();
            var path = "test.db";

            optionsBuilder.UseSqlite($"Filename={path}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransactionModel>()
                .HasKey(m => m.Id);
        }
    }
}