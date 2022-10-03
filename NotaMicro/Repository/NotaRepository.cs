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

        public Task<Nota> UpdateNota(Nota nota)
        {
            foreach (Nota oldNota in notaList)
            {
                if (oldNota.Id == nota.Id)
                {
                    if (nota.NotaFinal != 0)
                    {
                        oldNota.NotaFinal = nota.NotaFinal;
                    }
                    return Task.FromResult(nota);

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
