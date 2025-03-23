using WebAppTest.Models;

namespace WebAppTest.Services.Actividades
{
    public interface IActividades
    {
        Task<IEnumerable<ActividadesModel>> GetActividades();
        Task<int> AddActividad(ActividadesModel actividad);
    }
}
