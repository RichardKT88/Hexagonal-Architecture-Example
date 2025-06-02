using Hex.Arc.Core.Ports;
using Hex.Arch.Infrastructure.External.Settings;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace Hex.Arch.Infrastructure.External;

public class FixerExchangeRateService : IExchangeRateService
{
    private readonly HttpClient _httpClient;
    private readonly FixerSettings _settings;

    public FixerExchangeRateService(HttpClient httpClient, IOptions<FixerSettings> options)
    {
        _httpClient = httpClient;
        _settings = options.Value;
    }

    public async Task<decimal> GetExchangeRateAsync(string fromCurrency, string toCurrency)
    {
        var response = await _httpClient.GetAsync(
            $"https://api.fixer.io/latest?access_key={_settings.ApiKey}&base={fromCurrency}&symbols={toCurrency}");

        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<FixerResponse>();
        return content.Rates[toCurrency];
    }

    private class FixerResponse
    {
        public Dictionary<string, decimal> Rates { get; set; }
    }
}
