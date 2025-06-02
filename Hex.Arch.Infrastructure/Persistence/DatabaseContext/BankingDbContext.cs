using Hex.Arc.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Hex.Arch.Infrastructure.Persistence.DatabaseContext
{
    public class BankingDbContext : DbContext
    {
        public BankingDbContext(DbContextOptions<BankingDbContext> options) : base(options)
        {
            
        }
        public DbSet<Account> Accounts { get; set; }
    }
}
