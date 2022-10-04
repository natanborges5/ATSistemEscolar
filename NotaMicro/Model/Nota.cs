namespace NotaMicro.Model
{
    public class Nota
    {
        public Guid Id { get; set; }
        public Guid AtividadeId { get; set; }
        public Guid DisciplinaId { get; set; }
        public Guid AlunoId { get; set; }
        public string NotaFinal { get; set; }
    }
}
