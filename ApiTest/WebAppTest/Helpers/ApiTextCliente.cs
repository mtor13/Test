using System.Text.Json;

namespace WebAppTest.Helpers
{
    public static class ApiTextCliente
    {
        public static async Task<T> ReadContentAsync<T>(this HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode == false)
                throw new ApplicationException($"Error llamamdo al API: {response.ReasonPhrase}");

            var datos = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            var result = JsonSerializer.Deserialize<T>(
                datos, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return result;
        }
    }
}
