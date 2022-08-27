using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Confitec.Usuario.Infra.PersistenceAdapter.ADOSqlCommand
{
    public class UsuarioDBContext
    {
        private IConfiguration _config;

        public UsuarioDBContext(IConfiguration config)
        {
            _config = config;
        }

        public string GetConnectionString(string connectionType = "DefaultConnection")
        {
            var env = string.IsNullOrEmpty(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")) ? "json" : Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") + ".json";
            var Builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings." + env);

            if (_config == null)
                _config = Builder.Build();

            return _config.GetConnectionString(connectionType);

        }
    }
}
