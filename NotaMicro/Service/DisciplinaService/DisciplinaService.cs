using NotaMicro.Model;
using NotaMicro.Utils;

namespace NotaMicro.Service
{
    public class DisciplinaService : IDisciplinaService
    {
        private readonly HttpClient _client;

        public DisciplinaService(HttpClient client)
        {
            _client = client;
        }

        public const string basePath = "api/v1/Disciplina";

        public async Task<IEnumerable<Disciplina>> FindAllDisciplina()
        {
            var response = await _client.GetAsync(basePath);
            return await response.ReadContentAs<List<Disciplina>>();
        }

        public async Task<Disciplina> FindDisciplinaById(Guid id)
        {
            var response = await _client.GetAsync($"{basePath}/{id}");
            return await response.ReadContentAs<Disciplina>();
        }

        public async Task<Disciplina> CreateDisciplina(Disciplina disciplina)
        {
            var response = await _client.PostAsJson(basePath, disciplina);
            if (response.IsSuccessStatusCode) return await response.ReadContentAs<Disciplina>();
            else throw new Exception("Something went wrong when calling API");
        }

        public async Task<Disciplina> UpdateDisciplina(Disciplina disciplina)
        {
            var response = await _client.PutAsJson(basePath, disciplina);
            if (response.IsSuccessStatusCode) return await response.ReadContentAs<Disciplina>();
            else throw new Exception("Something went wrong when calling API");
        }

        public async Task<bool> DeleteDisciplina(Guid id)
        {
            var response = await _client.DeleteAsync($"{basePath}/{id}");
            if (response.IsSuccessStatusCode) return await response.ReadContentAs<bool>();
            else throw new Exception("Something went wrong when calling API");
        }
    }
}
