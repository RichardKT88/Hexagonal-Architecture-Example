namespace Hex.Arch.Core.Ports;

//(Secondary Port)
public interface IExchangeRateService
{
    Task<decimal> GetExchangeRateAsync(string fromCurrency, string toCurrency);
}