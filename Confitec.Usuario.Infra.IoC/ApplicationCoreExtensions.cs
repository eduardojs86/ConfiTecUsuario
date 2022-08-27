using Confitec.Usuario.ApplicationCore.Application._Ports.Services;
using Confitec.Usuario.ApplicationCore.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Confitec.Usuario.Infra.IoC
{
    public static class ApplicationCoreExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioApplicationService, UsuarioApplicationServices>();
            return services;
        }
    }
}
