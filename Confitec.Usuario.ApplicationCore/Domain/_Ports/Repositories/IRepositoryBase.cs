using Confitec.Usuario.ApplicationCore.Domain.Model;

namespace Confitec.Usuario.ApplicationCore.Domain._Ports.Repositories
{
    public interface IRepositoryBase<T>
    {
        T PostUsuario(CreateUsuarioModel usuario);
        T PutUsuario(UsuarioModel usuario);
        T GetUsuario();
        T DeleteUsuario(int id);
    }
}
