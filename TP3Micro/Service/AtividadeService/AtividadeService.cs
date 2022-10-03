using DisciplinaMicro.Model;
using DisciplinaMicro.Utils;

namespace DisciplinaMicro.Service.AtividadeService
{
    public class AtividadeService : IAtividadeService
    {
        private readonly HttpClient _client;

        public AtividadeService(HttpClient client)
        {
            _client = client;
        }

        public const string basePath = "api/v1/Atividade";

        public async Task<IEnumerable<Atividade>> FindAllAtividade()
        {
            var response = await _client.GetAsync(basePath);
            return await response.ReadContentAs<List<Atividade>>();
        }

        public async Task<Atividade> FindAtividadeById(Guid id)
        {
            var response = await _client.GetAsync($"{basePath}/{id}");
            return await response.ReadContentAs<Atividade>();
        }

        public async Task<Atividade> CreateAtividade(Atividade atividade)
        {
            var response = await _client.PostAsJson(basePath, atividade);
            if (response.IsSuccessStatusCode) return await response.ReadContentAs<Atividade>();
            else throw new Exception("Something went wrong when calling API");
        }

        public async Task<Atividade> UpdateAtividade(Atividade atividade)
        {
            var response = await _client.PutAsJson(basePath, atividade);
            if (response.IsSuccessStatusCode) return await response.ReadContentAs<Atividade>();
            else throw new Exception("Something went wrong when calling API");
        }

        public async Task<bool> DeleteAtividade(Guid id)
        {
            var response = await _client.DeleteAsync($"{basePath}/{id}");
            if (response.IsSuccessStatusCode) return await response.ReadContentAs<bool>();
            else throw new Exception("Something went wrong when calling API");
        }

        public async Task<IEnumerable<Atividade>> FindAtividadesPorDisciplina(Guid id)
        {
            var response = await _client.GetAsync(basePath);
            return await response.ReadContentAs<List<Atividade>>();
        }
    }
}
