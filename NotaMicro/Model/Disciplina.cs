using System.ComponentModel.DataAnnotations;

namespace NotaMicro.Model
{
    public class Disciplina
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public Guid ProfessorId { get; set; }
        public List<Guid> TarefasId { get; set; }
        public List<Guid> AlunosId { get; set; }
    }
}
