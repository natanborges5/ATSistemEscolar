using DisciplinaMicro.Model;

namespace DisciplinaMicro.Repository
{
    public interface IDisciplinaRepository
    {
         IEnumerable<Disciplina> ListAllDisciplina();
         Disciplina FindDisciplinaById(Guid id);
         Task<Disciplina> CreateDisciplina(Disciplina disciplina);
         Task<Disciplina> UpdateDisciplina(Disciplina disciplina);
         void DeleteDisciplina(Guid id);
    }
}
