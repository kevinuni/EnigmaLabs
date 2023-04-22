using Enigma.Domain.Base;
using Enigma.Repository.Base;

namespace Enigma.Api.Extensions;

public static class SqlServerExtension
{
    public static IServiceCollection ConfigureSqlServer(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<SqlServerSettings>(
            options =>
            {
                options.ConnectionString = configuration.GetSection("ConnectionStrings:DefaultConnection").Value;
            }
            );
        services.AddSingleton<SqlServerSettings>();
        services.AddScoped<IDatabase, SqlServerDatabase>();


        return services;
    }
}