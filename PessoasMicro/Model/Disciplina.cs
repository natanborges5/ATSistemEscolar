using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PessoasMicro.Model
{
    public class Disciplina
    {
        public Guid Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public Guid ProfessorId { get; set; }
        public List<Guid> TarefasId { get; set; }
        public List<Guid> AlunosId { get; set; }
    }
}
