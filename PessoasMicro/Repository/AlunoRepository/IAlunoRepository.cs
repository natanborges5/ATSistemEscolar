using PessoasMicro.Model;

namespace PessoasMicro.Repository.AlunoRepository
{
    public interface IAlunoRepository
    {
        IEnumerable<Aluno> ListAllAlunos();
        Aluno FindAlunoById(Guid id);
        Task<Aluno> CreateAluno(Aluno disciplina);
        Task<Aluno> UpdateAluno(Aluno disciplina);
        Task<bool> DeleteAluno(Guid id);
    }
}
