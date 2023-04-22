using Microsoft.AspNetCore.HttpLogging;

namespace Enigma.Api.Extensions;

public static class HttpLoggingExtension
{
    public static IServiceCollection ConfigureHttpLogging(this IServiceCollection services)
    {
        services.AddHttpLogging(logging =>
        {
            logging.RequestHeaders.Add("sec-ch-ua");
            logging.ResponseHeaders.Add("MyResponseHeader");
            logging.MediaTypeOptions.AddText("application/javascript");
            logging.MediaTypeOptions.AddText("application/json");
            logging.RequestBodyLogLimit = 4096;
            logging.ResponseBodyLogLimit = 4096;
            logging.LoggingFields = HttpLoggingFields.All;
        });

        return services;
    }

    public static IApplicationBuilder ConfigureHttpLogging(this IApplicationBuilder application)
    {
        application.UseHttpLogging();

        return application;
    }
}
