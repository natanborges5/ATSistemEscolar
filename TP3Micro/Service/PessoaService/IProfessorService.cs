using DisciplinaMicro.Model;

namespace DisciplinaMicro.Service.PessoaService
{
    public interface IProfessorService
    {
        Task<IEnumerable<Professor>> FindAllProfessor();
        Task<IEnumerable<Professor>> FindProfessorPorDisciplina(Guid id);
        Task<Professor> FindProfessorById(Guid id);
        Task<Professor> CreateProfessor(Professor professor);
        Task<Professor> UpdateProfessor(Professor professor);
        Task<bool> DeleteProfessor(Guid id);
    }
}
