using WebAppTest.Models;

namespace WebAppTest.Services.Usuarios
{
    public interface IUsuarios
    {
        //Task<IEnumerable<UsuariosModel>> GetUsuarios();
        Task<int> AddUsuario(UsuariosModel usuario);
    }
}
