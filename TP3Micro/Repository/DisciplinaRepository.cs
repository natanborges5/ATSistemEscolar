using DisciplinaMicro.Model;
using System.Collections;

namespace DisciplinaMicro.Repository
{
    public class DisciplinaRepository : IDisciplinaRepository
    {
        static List<Disciplina> turmaList = new List<Disciplina>();
        public IEnumerable<Disciplina> ListAllDisciplina()
        {
            return turmaList;
        }
        public Task<Disciplina> CreateDisciplina(Disciplina disciplina)
        {
            turmaList.Add(disciplina);
            return Task.FromResult(disciplina);
        }

        public Task<Disciplina> UpdateDisciplina(Disciplina disciplina)
        {
            foreach (Disciplina dis in turmaList)
            {
                if (dis.Id == disciplina.Id)
                {
                    if (disciplina.Nome != "")
                    {
                        dis.Nome = disciplina.Nome;
                    }
                    if (disciplina.ProfessorId == Guid.Empty)
                    {
                        dis.ProfessorId = disciplina.ProfessorId;
                    }
                    if (disciplina.AlunosId != null)
                    {
                        dis.AlunosId = disciplina.AlunosId;
                    }
                    if (disciplina.TarefasId != null)
                    {
                        dis.TarefasId = disciplina.TarefasId;
                    }
                    return Task.FromResult(disciplina);
                    
                }
            }
            return null;
        }
        public void DeleteDisciplina(Guid id)
        {
            var turma = FindDisciplinaById(id);
            turmaList.Remove(turma);
        }
        public Disciplina FindDisciplinaById(Guid id)
        {
            var disciplina = turmaList.Where(x => x.Id == id).FirstOrDefault();
            return disciplina;
        }
    }
}
