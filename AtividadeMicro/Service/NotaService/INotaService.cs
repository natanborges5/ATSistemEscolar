using AtividadeMicro.Model;

namespace AtividadeMicro.Service.NotaService
{
    public interface INotaService
    {
        Task<IEnumerable<Nota>> FindAllNota();
        Task<Nota> FindNotaById(Guid id);
        Task<Nota> CreateNota(Nota nota);
        Task<Nota> UpdateNota(Nota nota);
        Task<bool> DeleteNota(Guid id);
    }
}
