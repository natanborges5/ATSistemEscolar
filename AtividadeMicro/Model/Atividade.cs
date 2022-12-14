using System.ComponentModel.DataAnnotations;

namespace AtividadeMicro.Model
{
    public class Atividade
    {
        public Guid Id { get; set; }
        public Guid DisciplinaId { get; set; }
        public Guid AlunoId { get; set; }
        public int Prazo { get; set; }
        public string? Enunciado { get; set; }
        public string? Resposta { get; set; }
        public bool Concluida { get; set; }
        public DateTime? DataConclusao { get; set; }
        public DateTime DataSubmissao { get; set; }
    }
}
