using Api.Domain.interfaces.services;
using Api.Service.services;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.dependecyinjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IProjetoService, ProjetoService>();
        }
    }
}
