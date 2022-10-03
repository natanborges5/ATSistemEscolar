using DisciplinaMicro.Model;
using DisciplinaMicro.Utils;

namespace DisciplinaMicro.Service.PessoaService
{
    public class ProfessorService : IProfessorService
    {
        private readonly HttpClient _client;

        public ProfessorService(HttpClient client)
        {
            _client = client;
        }

        public const string basePath = "api/v1/Professor";

        public async Task<IEnumerable<Professor>> FindAllProfessor()
        {
            var response = await _client.GetAsync(basePath);
            return await response.ReadContentAs<List<Professor>>();
        }

        public async Task<Professor> FindProfessorById(Guid id)
        {
            var response = await _client.GetAsync($"{basePath}/{id}");
            return await response.ReadContentAs<Professor>();
        }

        public async Task<Professor> CreateProfessor(Professor atividade)
        {
            var response = await _client.PostAsJson(basePath, atividade);
            if (response.IsSuccessStatusCode) return await response.ReadContentAs<Professor>();
            else throw new Exception("Something went wrong when calling API");
        }

        public async Task<Professor> UpdateProfessor(Professor atividade)
        {
            var response = await _client.PutAsJson(basePath, atividade);
            if (response.IsSuccessStatusCode) return await response.ReadContentAs<Professor>();
            else throw new Exception("Something went wrong when calling API");
        }

        public async Task<bool> DeleteProfessor(Guid id)
        {
            var response = await _client.DeleteAsync($"{basePath}/{id}");
            if (response.IsSuccessStatusCode) return await response.ReadContentAs<bool>();
            else throw new Exception("Something went wrong when calling API");
        }

        public async Task<IEnumerable<Professor>> FindProfessorPorDisciplina(Guid id)
        {
            var response = await _client.GetAsync(basePath);
            return await response.ReadContentAs<List<Professor>>();
        }
    }
}
