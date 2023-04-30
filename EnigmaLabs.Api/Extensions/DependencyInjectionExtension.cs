using Enigma.Domain.Base;
using Enigma.Domain.IRepositories;
using Enigma.Repository.Base;
using Enigma.Repository;
using Enigma.Services;

namespace Enigma.Api.Extensions;

public static class DependencyInjectionExtension
{
    public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services)
    {
        //services.AddScoped<IDocument, Document>();
        services.AddScoped<IHangfireService, HangfireService>();

        #region Repository

        services.AddScoped(typeof(ICrudRepository<>), typeof(CrudRepository<>));
        //services.AddScoped<IPersonRepository, PersonaRepository>();

        #endregion Repository

        #region Services

        //services.AddScoped(typeof(ICrudService<>), typeof(CrudService<>));
        services.AddScoped<IPersonaService, PersonaService>();

        #endregion Services


        return services;
    }


}
