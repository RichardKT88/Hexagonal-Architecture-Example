using Hex.Arc.Core.Ports;
using Hex.Arch.Infrastructure.External;
using Hex.Arch.Infrastructure.External.Settings;
using Hex.Arch.Infrastructure.Persistence.DatabaseContext;
using Hex.Arch.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hex.Arch.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BankingDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("HexArchConnectionString"));
        });
        // Primary ports (interfaces) to infrastructure adapters
        services.AddScoped<IAccountRepository, EntityFrameworkAccountRepository>();

        // Secondary ports (interfaces) to infrastructure adapters
        services.AddScoped<INotificationService, SmtpNotificationService>();
        services.AddScoped<IExchangeRateService, FixerExchangeRateService>();

        services.AddHttpClient<IExchangeRateService, FixerExchangeRateService>();
        services.Configure<SmtpSettings>(configuration.GetSection("SmtpSettings"));
        services.Configure<FixerSettings>(configuration.GetSection("FixerSettings"));

        return services;
    }
}
