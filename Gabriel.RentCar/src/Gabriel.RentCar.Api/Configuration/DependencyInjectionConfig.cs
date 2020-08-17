using Microsoft.Extensions.DependencyInjection;
using Gabriel.RentCar.Business.Interfaces;
using Gabriel.RentCar.Data.Context;
using Gabriel.RentCar.Data.Repository;

namespace Gabriel.RentCar.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {

            services.AddTransient<MyContext>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IVendedorRepository, VendedorRepository>();
            services.AddTransient<IScoreRepository, ScoreRepository>();
            services.AddTransient<ICarroRepository, CarroRepository>();
            services.AddTransient<IVendaRepository, VendaRepository>();

            return services;
        }

    }
}
