namespace Hex.Arc.Core.Ports;

//(Secondary Port)
public interface IExchangeRateService
{
    Task<decimal> GetExchangeRateAsync(string fromCurrency, string toCurrency);
}