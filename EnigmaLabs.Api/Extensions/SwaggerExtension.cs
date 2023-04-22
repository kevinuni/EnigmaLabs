using Microsoft.OpenApi.Models;

namespace Enigma.Api.Extensions;

public static class SwaggerExtension
{
    public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Numion.Api", Version = "v1" });
        });
        return services;

    }
}
