using NotaMicro.Model;
using System.Text;

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
                    //oldNota.NotaFinal = NotaRecebidaRabbit();
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
        //public string NotaRecebidaRabbit()
        //{
        //    var factory = new ConnectionFactory() { HostName = "localhost" };

        //    using var connection = factory.CreateConnection();

        //    using var channel = connection.CreateModel();

        //    channel.QueueDeclare(
        //        queue: "letterbox",
        //        durable: false,
        //        exclusive: false,
        //        autoDelete: false,
        //        arguments: null);

        //    var consumer = new EventingBasicConsumer(channel);
        //    var NotaRecebida = "";
        //    consumer.Received += (model, ea) =>
        //    {
        //        var body = ea.Body.ToArray();
        //        var message = Encoding.UTF8.GetString(body);
        //        NotaRecebida = message;
        //    };

        //    channel.BasicConsume(queue: "letterbox", autoAck: true, consumer: consumer);
        //    return NotaRecebida;
        //}
    }
}
