namespace AtividadeMicro.Model
{
    public class Professor
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public List<Guid> DisciplinasId { get; set; }

    }
}
