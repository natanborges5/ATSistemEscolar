using DisciplinaMicro.Model;

namespace DisciplinaMicro.Service.PessoaService
{
    public interface IAlunoService
    {
        Task<IEnumerable<Aluno>> FindAllAluno();
        Task<IEnumerable<Aluno>> FindAlunoPorDisciplina(Guid id);
        Task<Aluno> FindAlunoById(Guid id);
        Task<Aluno> CreateAluno(Aluno aluno);
        Task<Aluno> UpdateAluno(Aluno aluno);
        Task<bool> DeleteAluno(Guid id);
    }
}
