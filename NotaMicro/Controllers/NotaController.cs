using Microsoft.AspNetCore.Mvc;
using NotaMicro.Model;
using NotaMicro.RabbitService;
using NotaMicro.Repository;
using NotaMicro.Service;

namespace NotaMicro.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class NotaController : Controller
    {
        private INotaRepository _repository;
        private IDisciplinaService _disciplina;
        private IAtividadeService _atividade;
        private IMessageProducer _messagePublisher;


        public NotaController(INotaRepository repository, IDisciplinaService disciplinaService,IAtividadeService atividade, IMessageProducer messageProducer)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _disciplina = disciplinaService;
            _atividade = atividade;
            _messagePublisher = messageProducer;

        }
        [HttpGet]
        public IEnumerable<Nota> Get()
        {
            return _repository.ListAllNotas();
        }
        [HttpPost]
        public async Task<ActionResult<Atividade>> Create([FromBody] Nota nota)
        {
            if (nota == null) return BadRequest();
            try
            {
                var newatividade = await _repository.CreateNota(nota);
                return Ok(newatividade);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> SubmitNota([FromBody]float notaNova,Guid id)
        {
            _repository.UpdateNota(notaNova,id);
            var notaSend = _repository.FindNotaById(id);
            _messagePublisher.SendMessage(notaSend);
            return Ok("Nota Modificada");
        }
    }
}
