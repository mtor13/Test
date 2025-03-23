using ApiTest.Models;
using ApiTest.Repository.UsuarioData;
using ApiTest.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace ApiTest.Repository.ActividadData
{
    public class ActividadRepository : IActividadRepository
    {
        readonly TestContext context;
        public ActividadRepository(TestContext _context) { context = _context; }

        public async Task<List<ActividadesViewModel>> GetActividades()
        {
            IUsuarioRepository usuario = new UsuarioRepository(context);
            if (context != null)
            {
                return await (from act in context.Actividades
                              join usr in context.Usuarios on act.IdUsuario equals usr.IdUsuario
                              orderby act.CreateDate descending
                              select new ActividadesViewModel
                              {
                                IdActividad = act.IdActividad,
                                CreateDate = act.CreateDate,
                                IdUsuario = act.IdUsuario,
                                NombreUsuario = usr.Nombre + " " + usr.Apellido,
                                Actividad = act.Actividad
                              }).ToListAsync();                    
            }

            return null;
        }

        public async Task<int> AddActividad(Actividades actividad)
        {
            if (context != null)
            {
                await context.Actividades.AddAsync(actividad);
                await context.SaveChangesAsync();
                return actividad.IdActividad;

            }
            return 0;
        }
    }
}
