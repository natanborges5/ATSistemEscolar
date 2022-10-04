using Microsoft.AspNetCore.Routing.Constraints;
using NotaMicro.Model;

namespace NotaMicro.Repository
{
    public class NotaRepository : INotaRepository
    {
        static List<Nota> notaList = new List<Nota>();
        public IEnumerable<Nota> ListAllNotas()
        {
            return notaList;
        }
        public Task<Nota> CreateNota(Nota nota)
        {
            notaList.Add(nota);
            return Task.FromResult(nota);
        }

        public Task<Nota> UpdateNota(float notanova, Guid notaId)
        {
            foreach (Nota oldNota in notaList)
            {
                if (oldNota.Id == notaId)
                {
                    oldNota.NotaFinal = notanova;
                    return Task.FromResult(oldNota);

                }
            }
            return null;
        }
        public Task<bool> DeleteNota(Guid id)
        {
            var nota = FindNotaById(id);
            notaList.Remove(nota);
            return Task.FromResult(true);
        }
        public Nota FindNotaById(Guid id)
        {
            var nota = notaList.Where(x => x.Id == id).FirstOrDefault();
            return nota;
        }
    }
}
