using AtividadeMicro.Model;
//using RabbitMQ.Client;
using System.Text;

namespace TP3Micro.Repository
{
    public class AtividadeRepository : IAtividadeRepository
    {

        static List<Atividade> atividadeList = new List<Atividade>();
        public IEnumerable<Atividade> ListAllAtividadesByTurma(Guid turmaId)
        {
            return atividadeList.Where(x => x.DisciplinaId == turmaId);
        }

        public Atividade FindAtividadeById(Guid atividadeId)
        {
            var atividade = atividadeList.FirstOrDefault(x => x.Id == atividadeId);
            if (atividade != null)
            {
                return atividade;
            }
            else return null;
            
        }

        public Task<Atividade> CreateAtividade(Atividade atividade)
        {
            atividadeList.Add(atividade);
            return Task.FromResult(atividade);
        }

        public void DeleteAtividade(Guid id)
        {
            var turma = FindAtividadeById(id);
            atividadeList.Remove(turma);
        }

        public IEnumerable<Atividade> ListAllAtividades()
        {
            return atividadeList;
        }
        public Task<Atividade> SubmitAtividade(SubmitAtividade atividade,Guid id)
        {
            foreach (Atividade oldAtividade in atividadeList)
            {
                if (oldAtividade.Id == id)
                {
                    oldAtividade.Resposta = atividade.Resposta;
                    oldAtividade.DataConclusao = DateTime.Today;
                    oldAtividade.Concluida = true;
                    return Task.FromResult(oldAtividade);

                }
            }
            return null;
        }

        //public string ProducerRabbit(string mensagem)
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

        //    var body = Encoding.UTF8.GetBytes(mensagem);

        //    channel.BasicPublish("", "letterbox", null, body);
        //    return "Mensagem enviada: "+ mensagem;
        //}
    }
}
