using Enigma.Api.Hangfire;
using Hangfire;
using Hangfire.SqlServer;

namespace Enigma.Api.Extensions;

public static class HangfireExtension
{
    public static IServiceCollection ConfigureHangfire(this IServiceCollection services, ConfigurationManager configuration)
    {
        string str = configuration.GetSection("ConnectionStrings:DefaultConnection").Value;

        // Add Hangfire services.
        services.AddHangfire(configuration => configuration
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseSqlServerStorage(str, new SqlServerStorageOptions
            {
                CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                QueuePollInterval = TimeSpan.Zero,
                UseRecommendedIsolationLevel = true,
                DisableGlobalLocks = true
            }));

        // Add the processing server as IHostedService
        services.AddHangfireServer();

        return services;

    }

    public static IApplicationBuilder UseHangfire(this IApplicationBuilder application)
    {
        application.UseHangfireDashboard("/hangfire", new DashboardOptions
        {
            Authorization = new[] { new HangfireAuthorizationFilter() }
        });

        return application;
    }
}