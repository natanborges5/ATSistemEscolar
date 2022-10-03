using NotaMicro.Model;

namespace NotaMicro.Repository
{
    public interface INotaRepository
    {
        IEnumerable<Nota> ListAllNotas();
        Nota FindNotaById(Guid id);
        Task<Nota> CreateNota(Nota disciplina);
        Task<Nota> UpdateNota(Nota disciplina);
        Task<bool> DeleteNota(Guid id);
    }
}
