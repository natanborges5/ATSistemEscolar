using PessoasMicro.Model;

namespace PessoasMicro.Repository.ProfessorRepository
{
    public class ProfessorRepository : IProfessorRepository
    {
        static List<Professor> professorList = new List<Professor>();
        public IEnumerable<Professor> ListAllProfessor()
        {
            return professorList;
        }
        public Task<Professor> CreateProfessor(Professor professor)
        {
            professorList.Add(professor);
            return Task.FromResult(professor);
        }

        public Task<Professor> UpdateProfessor(Professor professor)
        {
            foreach (Professor oldProfessor in professorList)
            {
                if (oldProfessor.Id == professor.Id)
                {
                    if (professor.Nome != "")
                    {
                        oldProfessor.Nome = professor.Nome;
                    }
                    if (professor.DisciplinasId.Count() > 0)
                    {
                        oldProfessor.DisciplinasId = professor.DisciplinasId;
                    }
                    return Task.FromResult(professor);

                }
            }
            return null;
        }
        public Task<bool> DeleteProfessor(Guid id)
        {
            var professor = FindProfessorById(id);
            professorList.Remove(professor);
            return Task.FromResult(true);
        }
        public Professor FindProfessorById(Guid id)
        {
            var professor = professorList.Where(x => x.Id == id).FirstOrDefault();
            return professor;
        }
    }
}
