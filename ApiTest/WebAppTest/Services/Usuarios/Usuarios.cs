using WebAppTest.Models;
using System.Text.Json;

namespace WebAppTest.Services.Usuarios
{
    public class Usuarios : IUsuarios
    {
        private readonly HttpClient _client;
        public const string BasePath = "/AddUsuario";

        public Usuarios(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<int> AddUsuario(UsuariosModel usuario)
        {
            var usuarioJson = JsonSerializer.Serialize(usuario);
            var dataContent = new StringContent(usuarioJson);
            var response = await _client.PostAsync(BasePath, dataContent);
            string result = response.Content.ReadAsStringAsync().Result;
            return 0;
        }
    }
}
