using ApiTest.Models;
using ApiTest.ViewModel;

namespace ApiTest.Repository.ActividadData
{
    public interface IActividadRepository
    {
        Task<List<ActividadesViewModel>> GetActividades();
        Task<int> AddActividad(Actividades actividad);
    }
}
