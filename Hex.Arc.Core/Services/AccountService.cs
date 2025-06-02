using Hex.Arc.Core.Ports;

namespace Hex.Arc.Core.Services;

public class AccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly INotificationService _notificationService;
    private readonly IExchangeRateService _exchangeRateService;

    public AccountService(
        IAccountRepository accountRepository,
        INotificationService notificationService,
        IExchangeRateService exchangeRateService)
    {
        _accountRepository = accountRepository;
        _notificationService = notificationService;
        _exchangeRateService = exchangeRateService;
    }

    public async Task TransferFundsAsync(
        Guid fromAccountId,
        Guid toAccountId,
        decimal amount)
    {
        var fromAccount = await _accountRepository.GetByIdAsync(fromAccountId);
        var toAccount = await _accountRepository.GetByIdAsync(toAccountId);

        if (fromAccount == null || toAccount == null)
            throw new ArgumentException("Account not found");

        if (fromAccount.Currency != toAccount.Currency)
        {
            var rate = await _exchangeRateService.GetExchangeRateAsync(
                fromAccount.Currency,
                toAccount.Currency);
            amount *= rate;
        }

        fromAccount.Withdraw(amount);
        toAccount.Deposit(amount);

        await _accountRepository.SaveAsync(fromAccount);
        await _accountRepository.SaveAsync(toAccount);

        await _notificationService.SendTransferNotification(
            $"Transfer of {amount} completed",
            "customer@email.com");
    }
}
