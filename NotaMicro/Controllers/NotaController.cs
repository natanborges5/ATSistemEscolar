using Microsoft.AspNetCore.Mvc;
using NotaMicro.Model;
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


        public NotaController(INotaRepository repository, IDisciplinaService disciplinaService,IAtividadeService atividade)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _disciplina = disciplinaService;
            _atividade = atividade;

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
        [HttpPut]
        public async Task<ActionResult<Nota>> ReceberNota(Nota nota)
        {
            var newNota = await _repository.UpdateNota(nota);
            return Ok(newNota);
                
        }

    }
}
