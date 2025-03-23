using ApiTest.Models;
using ApiTest.Repository.ActividadData;
using Microsoft.EntityFrameworkCore;

namespace ApiTest.Repository.UsuarioData
{
    public class UsuarioRepository : IUsuarioRepository
    {
        readonly TestContext context;
        public UsuarioRepository(TestContext _context) { context = _context; }

        public async Task<List<Usuarios>> GetUsuarios()
        {
            if (context != null)
            {
                return await context.Usuarios.ToListAsync();
            }

            return null;
        }

        public async Task<int> AddUsuario(Usuarios usuario)
        {
            IActividadRepository actividadRepository = new ActividadRepository(context);
            Actividades actividad = new Actividades();
            
            var _usuario = await context.Usuarios
                                .Where(usr => usr.CorreoElectronico.ToLower() == usuario.CorreoElectronico.ToLower())
                                .FirstOrDefaultAsync<Usuarios>();
            if (_usuario == null)
            {                
                if (context != null)
                {
                    await context.Usuarios.AddAsync(usuario);
                    await context.SaveChangesAsync();
                    actividad.CreateDate = DateTime.Now;
                    actividad.IdUsuario = (int)usuario.IdUsuario;
                    actividad.Actividad = "Usuario Creado";
                    await context.Actividades.AddAsync(actividad);
                    await context.SaveChangesAsync();
                    return (int)usuario.IdUsuario;

                }
            }
            return 0;
        }
    }
}
