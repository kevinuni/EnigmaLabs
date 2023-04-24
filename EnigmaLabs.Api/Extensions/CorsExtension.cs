namespace Enigma.Api.Extensions;

public static class CorsExtension
{
    public static IServiceCollection ConfigureCors(this IServiceCollection services, string policyName)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(name: policyName,
                policy =>
                {
                    policy
                        .AllowAnyOrigin()
                        //.WithOrigins("http://metasil.synology.me")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                        //.WithExposedHeaders("x-pagination", "x-scoreddata");
                });
        });
        return services;
    }

    public static IApplicationBuilder AppUserCors(this IApplicationBuilder application, string policyName)
    {
        application.UseCors(policyName);
        return application;
    }

}
