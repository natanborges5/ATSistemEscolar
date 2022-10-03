using AtividadeMicro.Model;
using AtividadeMicro.Utils;

namespace AtividadeMicro.Service.NotaService
{
    public class NotaService : INotaService
    {
        private readonly HttpClient _client;

        public NotaService(HttpClient client)
        {
            _client = client;
        }

        public const string basePath = "api/v1/Nota";

        public async Task<IEnumerable<Nota>> FindAllNota()
        {
            var response = await _client.GetAsync(basePath);
            return await response.ReadContentAs<List<Nota>>();
        }

        public async Task<Nota> FindNotaById(Guid id)
        {
            var response = await _client.GetAsync($"{basePath}/{id}");
            return await response.ReadContentAs<Nota>();
        }

        public async Task<Nota> CreateNota(Nota nota)
        {
            var response = await _client.PostAsJson(basePath, nota);
            if (response.IsSuccessStatusCode) return await response.ReadContentAs<Nota>();
            else throw new Exception("Something went wrong when calling API");
        }

        public async Task<Nota> UpdateNota(Nota nota)
        {
            var response = await _client.PutAsJson(basePath, nota);
            if (response.IsSuccessStatusCode) return await response.ReadContentAs<Nota>();
            else throw new Exception("Something went wrong when calling API");
        }

        public async Task<bool> DeleteNota(Guid id)
        {
            var response = await _client.DeleteAsync($"{basePath}/{id}");
            if (response.IsSuccessStatusCode) return await response.ReadContentAs<bool>();
            else throw new Exception("Something went wrong when calling API");
        }
    }
}
