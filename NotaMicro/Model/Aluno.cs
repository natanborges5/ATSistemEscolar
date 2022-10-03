namespace NotaMicro.Model
{
    public class Aluno
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public List<Guid> DisciplinasId { get; set; }
    }
}
