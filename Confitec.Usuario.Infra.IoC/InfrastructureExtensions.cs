using Confitec.Usuario.ApplicationCore.Domain._Ports.Repositories;
using Confitec.Usuario.ApplicationCore.Domain.Model;
using Confitec.Usuario.Infra.PersistenceAdapter.ADOSqlCommand;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Confitec.Usuario.Infra.IoC
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddPersistenceAdapters(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<Infra.PersistenceAdapter.ADOSqlCommand.UsuarioDBContext>();
            services.AddScoped<IUsuarioRetository<object>, UsuarioRepository>();
            return services;
        }
    }
}
