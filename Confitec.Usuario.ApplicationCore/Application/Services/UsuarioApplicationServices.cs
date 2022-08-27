using Confitec.Usuario.ApplicationCore.Application._Ports.Services;
using Confitec.Usuario.ApplicationCore.Domain._Ports.Repositories;
using Confitec.Usuario.ApplicationCore.Domain.Model;

namespace Confitec.Usuario.ApplicationCore.Application.Services
{
    public class UsuarioApplicationServices : IUsuarioApplicationService
    {
        private readonly IUsuarioRetository<object> _UsuarioRepository;

        public UsuarioApplicationServices(IUsuarioRetository<object> UsuarioRepository)
        {
            _UsuarioRepository = UsuarioRepository;
        }


        public object IncluirUsuario(CreateUsuarioModel usuario)
        {
            return _UsuarioRepository.PostUsuario(usuario);
        }

        public object AtualizarUsuario(UsuarioModel usuario)
        {
            return _UsuarioRepository.PutUsuario(usuario);
        }

        public object BuscarUsuario()
        {
            return _UsuarioRepository.GetUsuario();
        }

        public object DeletarUsuario(int id)
        {
            return _UsuarioRepository.DeleteUsuario(id);
        }
    }
}
