using Confitec.Usuario.ApplicationCore.Application._Ports.Services;
using Confitec.Usuario.ApplicationCore.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Confitec.Usuario.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioApplicationService _UsuarioApplicationService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UsuarioController(IUsuarioApplicationService UsuarioApplicationService,
            IHttpContextAccessor httpContextAccessor)
        {
            _UsuarioApplicationService = UsuarioApplicationService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("IncluirUsuario")]
        public IActionResult IncluirUsuario(CreateUsuarioModel usuario)
        {
            try
            {
                object retorno = _UsuarioApplicationService.IncluirUsuario(usuario);

                if (retorno is ErroModel)
                {
                    return Unauthorized(retorno);
                }
                else
                {
                    ErroModel retornos = new ErroModel();
                    retornos.Codigo = 200;
                    retornos.Mensagem = "Usuário incluído com sucesso.";
                    return Ok(retornos);
                }
            }
            catch (Exception)
            {
                return BadRequest(string.Format("{0}", "Não foi possível incluir o Usuário."));
            }
        }

        [HttpPut("AtualizarUsuario")]
        public IActionResult AtualizarUsuario(UsuarioModel usuario)
        {
            try
            {
                object retorno = _UsuarioApplicationService.AtualizarUsuario(usuario);

                if (retorno is ErroModel)
                {
                    return Unauthorized(retorno);
                }
                else
                {
                    ErroModel retornos = new ErroModel();
                    retornos.Codigo = 200;
                    retornos.Mensagem = "Usuário atualizado com sucesso.";
                    return Ok(retornos);
                }
            }
            catch (Exception)
            {
                return BadRequest(string.Format("{0}", "Não foi possível atualizar os dados do Usuário."));
            }
        }

        [HttpGet("BuscarUsuario")]
        public IActionResult BuscarUsuario()
        {
            try
            {
                object retorno = _UsuarioApplicationService.BuscarUsuario();

                if (retorno is UsuarioModel)
                {
                    if ((retorno as UsuarioModel).Id > 0)
                    {
                        return Ok(retorno); //200
                    }
                    else
                    {
                        return Unauthorized(retorno); //401
                    }
                }
                else
                {
                    return Unauthorized(retorno); //401
                }
            }
            catch (Exception)
            {
                return BadRequest(string.Format("{0}", "Não foi possível localizar nenhum Usuário."));
            }
        }

        [HttpDelete("DeletarUsuario")]
        public IActionResult DeletarUsuario(int id)
        {
            try
            {
                object retorno = _UsuarioApplicationService.DeletarUsuario(id);

                if (retorno is ErroModel)
                {
                    return Unauthorized(retorno);
                }
                else
                {
                    ErroModel retornos = new ErroModel();
                    retornos.Codigo = 200;
                    retornos.Mensagem = "Usuário Excluído com sucesso.";
                    return Ok(retornos);
                }
            }
            catch (Exception)
            {
                return BadRequest(string.Format("{0}", "Não foi possível excluir usuário."));
            }
        }

    }
}
