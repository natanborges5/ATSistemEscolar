using PessoasMicro.Model;

namespace PessoasMicro.Repository.AlunoRepository
{
    public class AlunoRepository : IAlunoRepository
    {
        static List<Aluno> alunoList = new List<Aluno>();
        public IEnumerable<Aluno> ListAllAlunos()
        {
            return alunoList;
        }
        public Task<Aluno> CreateAluno(Aluno aluno)
        {
            alunoList.Add(aluno);
            return Task.FromResult(aluno);
        }

        public Task<Aluno> UpdateAluno(Aluno aluno)
        {
            foreach (Aluno oldAluno in alunoList)
            {
                if (oldAluno.Id == aluno.Id)
                {
                    if (aluno.Nome != "")
                    {
                        oldAluno.Nome = aluno.Nome;
                    }
                    if (aluno.DisciplinasId.Count() > 0)
                    {
                        oldAluno.DisciplinasId = aluno.DisciplinasId;
                    }
                    return Task.FromResult(aluno);

                }
            }
            return null;
        }
        public Task<bool>DeleteAluno(Guid id)
        {
            var aluno = FindAlunoById(id);
            alunoList.Remove(aluno);
            return Task.FromResult(true);
        }
        public Aluno FindAlunoById(Guid id)
        {
            var aluno = alunoList.Where(x => x.Id == id).FirstOrDefault();
            return aluno;
        }
    }
}
