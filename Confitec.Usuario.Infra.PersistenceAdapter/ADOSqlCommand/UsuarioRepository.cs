using Confitec.Usuario.ApplicationCore.Domain._Ports.Repositories;
using Confitec.Usuario.ApplicationCore.Domain.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Confitec.Usuario.Infra.PersistenceAdapter.ADOSqlCommand
{
    public class UsuarioRepository : ADOSqlCommands, IUsuarioRetository<object> 
    {
        enum Escolaridade
        {
            Infantil = 1,
            Fundamental = 2,
            Médio = 3,
            Superior = 4
        };

        public UsuarioRepository(IConfiguration config) : base(config)
        {
        }

        public object PostUsuario(CreateUsuarioModel usuario)
        {
            try
            {
                if (ValidarEmail(usuario.Email) == false )
                {
                    ErroModel erros = new ErroModel();
                    erros.Codigo = 401;
                    erros.Mensagem = "E-mail inválido.";
                    return erros;
                }

                if (ValidarEscolaridade(usuario.EscolaridadeId) == false)
                {
                    ErroModel erros = new ErroModel();
                    erros.Codigo = 401;
                    erros.Mensagem = "Escolaridade inválida. Use 1 para Infantil, 2 para Fundamental, 3 para Médio ou 4 para Superior";
                    return erros;
                }

                if (usuario.DataNascimento > DateTime.Now)
                {
                    ErroModel erros = new ErroModel();
                    erros.Codigo = 401;
                    erros.Mensagem = "A data de nascimento não pode ser maior que hoje";
                    return erros;
                }

                List<Dictionary<string, object>> tabelaDados = ExecuteProcedure("[dbo].[PROC_INCLUIR_USUARIO]",
                    new Dictionary<string, object>()
                    {
                        {"@Nome", usuario.Nome},
                        {"@Sobrenome", usuario.Sobrenome},
                        {"@Email", usuario.Email},
                        {"@DataNascimento", usuario.DataNascimento},
                        {"@EscolaridadeId", usuario.EscolaridadeId},
                        {"@HistoricoEscolarId", usuario.Nome}
                    });

                    return "Usuário incluído com sucesso.";
            }
            catch (Exception ex)
            {
                ErroModel erros = new ErroModel();
                erros.Codigo = 404;
                erros.Mensagem = string.Format("{0}", "Usuário não incluído." + ex);
                return erros;
            }
        }
        public object PutUsuario(UsuarioModel usuario)
        {
            try
            {
                if (ValidarEmail(usuario.Email) == false)
                {
                    ErroModel erros = new ErroModel();
                    erros.Codigo = 401;
                    erros.Mensagem = "E-mail inválido.";
                    return erros;
                }

                if (ValidarEscolaridade(usuario.EscolaridadeId) == false)
                {
                    ErroModel erros = new ErroModel();
                    erros.Codigo = 401;
                    erros.Mensagem = "Escolaridade inválida. Use 1 para Infantil, 2 para Fundamental, 3 para Médio ou 4 para Superior";
                    return erros;
                }

                List<Dictionary<string, object>> tabelaDados = ExecuteProcedure("[dbo].[PROC_EDITAR_USUARIO]",
                new Dictionary<string, object>()
                {
                    {"@Id", usuario.Id},
                    {"@Nome", usuario.Nome},
                    {"@Sobrenome", usuario.Sobrenome},
                    {"@Email", usuario.Email},
                    {"@DataNascimento", usuario.DataNascimento},
                    {"@EscolaridadeId", usuario.EscolaridadeId},
                    {"@HistoricoEscolarId", usuario.Nome}
                }); ;

                return "Usuário atualizado com sucesso.";
            }
            catch (Exception ex)
            {
                ErroModel erros = new ErroModel();
                erros.Codigo = 404;
                erros.Mensagem = string.Format("{0}", "Usuário não atualizado." + ex);
                return erros;
            }
        }
        public object GetUsuario()
        {
            try
            {
                List<Dictionary<string, object>> tabelaDados = ExecuteProcedure("[dbo].[PROC_BUSCAR_USUARIO]",
                new Dictionary<string, object>()
                {
                });

                if (tabelaDados.Count > 0)
                {
                    UsuarioModel generoModel;
                    List<UsuarioModel> usuario = new List<UsuarioModel>();

                    for (int i = 0; i < tabelaDados.Count; i++)
                    {
                        IDictionary<string, object> registroPergunta = tabelaDados[i];
                        generoModel = new UsuarioModel();
                        foreach (PropertyInfo propriedade in generoModel.GetType().GetProperties())
                        {
                            if (registroPergunta[propriedade.Name] != null && registroPergunta[propriedade.Name] != DBNull.Value)
                            {
                                propriedade.SetValue(generoModel, registroPergunta[propriedade.Name]);
                            }
                        }
                        usuario.Add(generoModel);
                    }

                    return usuario;
                }
                else
                {
                    ErroModel erros = new ErroModel();
                    erros.Codigo = 401;
                    erros.Mensagem = "Usuário não localizado.";
                    return erros;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public object DeleteUsuario(int id)
        {
            try
            {
                List<Dictionary<string, object>> tabelaDados = ExecuteProcedure("[dbo].[PROC_EXCLUIR_USUARIO]",
               new Dictionary<string, object>()
               {
                    {"@Id", id}
               }); ;

                return "Usuário excluído com sucesso.";
            }
            catch (Exception ex)
            {
                ErroModel erros = new ErroModel();
                erros.Codigo = 404;
                erros.Mensagem = string.Format("{0}", "Usuário não excluído." + ex);
                return erros;
            }
        }

        public bool ValidarEmail(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }

        public bool ValidarEscolaridade(int id)
        {
            return Enum.IsDefined(typeof(Escolaridade), id);
        }
    }
}
