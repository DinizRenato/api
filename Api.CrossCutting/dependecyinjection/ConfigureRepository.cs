using System;
using Api.Data.context;
using Api.Data.implementations;
using Api.Data.repository;
using Api.Domain.interfaces;
using Api.Domain.repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.dependecyinjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            serviceCollection.AddScoped<IProjetoRepository, ProjetoImplementation>();
            serviceCollection.AddScoped<IMetadadoRepository, MetadadoImplementation>();

            serviceCollection.AddDbContext<MyContext>(
                options => options.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONNECTION"))
            );
        }
    }
}
