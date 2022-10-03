using DisciplinaMicro.Model;
using DisciplinaMicro.Utils;

namespace DisciplinaMicro.Service.PessoaService
{
    public class AlunoService : IAlunoService
    {
        private readonly HttpClient _client;

        public AlunoService(HttpClient client)
        {
            _client = client;
        }

        public const string basePath = "api/v1/Aluno";

        public async Task<IEnumerable<Aluno>> FindAllAluno()
        {
            var response = await _client.GetAsync(basePath);
            return await response.ReadContentAs<List<Aluno>>();
        }

        public async Task<Aluno> FindAlunoById(Guid id)
        {
            var response = await _client.GetAsync($"{basePath}/{id}");
            return await response.ReadContentAs<Aluno>();
        }

        public async Task<Aluno> CreateAluno(Aluno atividade)
        {
            var response = await _client.PostAsJson(basePath, atividade);
            if (response.IsSuccessStatusCode) return await response.ReadContentAs<Aluno>();
            else throw new Exception("Something went wrong when calling API");
        }

        public async Task<Aluno> UpdateAluno(Aluno atividade)
        {
            var response = await _client.PutAsJson(basePath, atividade);
            if (response.IsSuccessStatusCode) return await response.ReadContentAs<Aluno>();
            else throw new Exception("Something went wrong when calling API");
        }

        public async Task<bool> DeleteAluno(Guid id)
        {
            var response = await _client.DeleteAsync($"{basePath}/{id}");
            if (response.IsSuccessStatusCode) return await response.ReadContentAs<bool>();
            else throw new Exception("Something went wrong when calling API");
        }

        public async Task<IEnumerable<Aluno>> FindAlunoPorDisciplina(Guid id)
        {
            var response = await _client.GetAsync(basePath);
            return await response.ReadContentAs<List<Aluno>>();
        }
    }
}
