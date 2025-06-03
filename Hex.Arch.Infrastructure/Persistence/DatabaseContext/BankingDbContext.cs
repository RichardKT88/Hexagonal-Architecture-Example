using Hex.Arch.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Hex.Arch.Infrastructure.Persistence.DatabaseContext
{
    public class BankingDbContext : DbContext
    {
        public BankingDbContext(DbContextOptions<BankingDbContext> options) : base(options)
        {

        }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.Balance)
                      .HasPrecision(18, 2);
                entity.HasData(
                    new Account(new Guid("11111111-1111-1111-1111-111111111111"), "100200300", "BRL"),
                    new Account(new Guid("22222222-2222-2222-2222-222222222222"), "200300400", "USD"));

            });
        }
    }
}
