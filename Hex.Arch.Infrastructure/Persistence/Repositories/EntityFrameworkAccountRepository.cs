using Hex.Arc.Core.Domain;
using Hex.Arc.Core.Ports;
using Hex.Arch.Infrastructure.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Hex.Arch.Infrastructure.Persistence.Repositories;

public class EntityFrameworkAccountRepository : IAccountRepository
{
    private readonly BankingDbContext _context;

    public EntityFrameworkAccountRepository(BankingDbContext context)
    {
        _context = context;
    }

    public async Task<Account?> GetByIdAsync(Guid id)
    {
        return await _context.Accounts.FindAsync(id);
    }

    public async Task<Account?> GetByAccountNumberAsync(string accountNumber)
    {
        return await _context.Accounts
            .FirstOrDefaultAsync(a => a.AccountNumber == accountNumber);
    }

    public async Task SaveAsync(Account account)
    {
        if (_context.Entry(account).State == EntityState.Detached)
            _context.Accounts.Add(account);

        await _context.SaveChangesAsync();
    }
}
