using NotaMicro.Model;

namespace NotaMicro.Service
{
    public interface IDisciplinaService
    {
        Task<IEnumerable<Disciplina>> FindAllDisciplina();
        Task<Disciplina> FindDisciplinaById(Guid id);
        Task<Disciplina> CreateDisciplina(Disciplina product);
        Task<Disciplina> UpdateDisciplina(Disciplina product);
        Task<bool> DeleteDisciplina(Guid id);
    }
}
