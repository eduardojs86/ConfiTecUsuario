using Confitec.Usuario.ApplicationCore.Domain.Model;

namespace Confitec.Usuario.ApplicationCore.Application._Ports.Services
{
    public interface IUsuarioApplicationService
    {
        object IncluirUsuario(CreateUsuarioModel usuario);
        object AtualizarUsuario(UsuarioModel usuario);
        object BuscarUsuario();
        object DeletarUsuario(int id);
    }
}
