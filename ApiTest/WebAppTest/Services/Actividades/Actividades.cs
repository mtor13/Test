using WebAppTest.Helpers;
using WebAppTest.Models;

namespace WebAppTest.Services.Actividades
{
    public class Actividades : IActividades
    {
        private readonly HttpClient _client;
        public const string BasePath = "/GetActividades";

        public Actividades(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<ActividadesModel>> GetActividades()
        {
            var response = await _client.GetAsync(BasePath);

            return await response.ReadContentAsync<List<ActividadesModel>>();
        }

        public async Task<int> AddActividad(ActividadesModel actividad)
        {
            //var response = await _client.PostAsync(BasePath,new HttpContent(actividad))
            //return await response.
            return 0;
        }
    }
}
