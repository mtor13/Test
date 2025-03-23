using ApiTest.Models;

namespace ApiTest.Repository.UsuarioData
{
    public interface IUsuarioRepository
    {
        Task<List<Usuarios>> GetUsuarios();
        Task<int> AddUsuario(Usuarios usuario);
    }
}
