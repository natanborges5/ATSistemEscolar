using System.ComponentModel.DataAnnotations;

namespace AtividadeMicro.Model
{
    public class Disciplina
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Guid ProfessorId { get; set; }
        public List<Guid> TarefasId { get; set; }
        public List<Guid> AlunosId { get; set; }

    }
}
