using Hex.Arch.Core.Domain;

namespace Hex.Arch.Core.Ports;
//(Primary Port)
public interface IAccountRepository
{
    Task<Account?> GetByIdAsync(Guid id);
    Task<Account?> GetByAccountNumberAsync(string accountNumber);
    Task SaveAsync(Account account);
}
