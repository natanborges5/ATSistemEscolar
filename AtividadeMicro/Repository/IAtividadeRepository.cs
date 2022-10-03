using AtividadeMicro.Model;

namespace TP3Micro.Repository
{
    public interface IAtividadeRepository
    {
         IEnumerable<Atividade> ListAllAtividadesByTurma(Guid turmaId);
         IEnumerable<Atividade> ListAllAtividades();
         Atividade FindAtividadeById(Guid atividadeId);
         Task<Atividade> CreateAtividade(Atividade atividade);
         Task<Atividade> SubmitAtividade(SubmitAtividade atividade, Guid id);
         void DeleteAtividade(Guid id);
    }
}
