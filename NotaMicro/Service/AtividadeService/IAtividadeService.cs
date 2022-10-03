using NotaMicro.Model;

namespace NotaMicro.Service
{
    public interface IAtividadeService
    {
        Task<IEnumerable<Atividade>> FindAllAtividade();
        Task<IEnumerable<Atividade>> FindAtividadesPorDisciplina(Guid id);
        Task<Atividade> FindAtividadeById(Guid id);
        Task<Atividade> CreateAtividade(Atividade atividade);
        Task<Atividade> UpdateAtividade(Atividade atividade);
        Task<bool> DeleteAtividade(Guid id);
    }
}
