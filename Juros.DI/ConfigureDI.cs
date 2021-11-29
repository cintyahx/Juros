using FluentValidation;
using Juros.Domain.Dtos;
using Juros.Domain.Interfaces;
using Juros.Domain.Validators;
using Juros.Infra.Context;
using Juros.Infra.Repositories;
using Juros.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Juros.DI
{
    public static class ConfigureDI
    {
        public static IServiceCollection ConfigureInjections(this IServiceCollection services, IConfiguration configuration)
        {
            string mySqlConnectionStr = configuration.GetConnectionString("Crud");
            services.AddDbContext<JurosContext>(options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));
            services.AddScoped<JurosContext, JurosContext>();

            services.InjectRepositories();
            services.InjectServices();
            services.InjectValidators();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }

        private static void InjectServices(this IServiceCollection services)
        {
            services.AddScoped<ITaxaJurosService, TaxaJurosService>();
        }

        private static void InjectRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITaxaJurosRepository, TaxaJurosRepository>();
        }

        private static void InjectValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<TaxaJurosDto>, TaxaJurosValidator>();
        }
    }
}
