using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Confitec.Usuario.Infra.PersistenceAdapter.ADOSqlCommand
{
    public class ADOSqlCommands : UsuarioDBContext
    {
        public ADOSqlCommands(IConfiguration config) : base(config)
        {

        }

        public List<Dictionary<string, object>> ExecuteProcedure(string commandText, IDictionary<string, object> dbParams = null)
        {
            using (SqlConnection con = new SqlConnection(this.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand(commandText, con);
                cmd.CommandType = CommandType.StoredProcedure;

                if (cmd.Connection.State != ConnectionState.Open)
                {
                    cmd.Connection.Open();
                }

                if (dbParams != null)
                {
                    foreach (var dbParam in dbParams)
                    {
                        cmd.Parameters.AddWithValue(dbParam.Key, dbParam.Value);
                    }
                }

                return MapDataReader(cmd.ExecuteReader());
            }

        }

        private List<Dictionary<string, object>> MapDataReader(SqlDataReader sqlDataReader)
        {
            List<Dictionary<string, object>> tabelaDados = new List<Dictionary<string, object>>();

            while (sqlDataReader.Read())
            {
                Dictionary<string, object> linha = new Dictionary<string, object>();

                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    linha.Add(sqlDataReader.GetName(i), sqlDataReader.GetValue(i));
                }

                tabelaDados.Add(linha);
            }
            return tabelaDados;
        }
    }
}
