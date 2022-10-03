using PessoasMicro.Model;

namespace PessoasMicro.Repository.ProfessorRepository
{
    public interface IProfessorRepository
    {
        IEnumerable<Professor> ListAllProfessor();
        Professor FindProfessorById(Guid id);
        Task<Professor> CreateProfessor(Professor disciplina);
        Task<Professor> UpdateProfessor(Professor disciplina);
        Task<bool> DeleteProfessor(Guid id);
    }
}
