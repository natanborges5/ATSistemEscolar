using AtividadeMicro.Model;
using AtividadeMicro.Service.DisciplinaService;
using AtividadeMicro.Service.NotaService;
using Microsoft.AspNetCore.Mvc;
using TP3Micro.Repository;

namespace AtividadeMicro.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AtividadeController : Controller
    {
        private IAtividadeRepository _repository;
        private IDisciplinaService _disciplina;
        private INotaService _nota;

        public AtividadeController(IAtividadeRepository repository, IDisciplinaService disciplinaService, INotaService notaService)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _disciplina = disciplinaService;
            _nota = notaService;

        }
        [HttpGet]
        public IEnumerable<Atividade> Get()
        {
            return _repository.ListAllAtividades();
        }
        [HttpGet("{id}")]
        public IEnumerable<Atividade> GetAtividadePorDisciplina(Guid id)
        {
            return _repository.ListAllAtividadesByTurma(id);
        }
        //[HttpGet]
        //public async Task<IActionResult> ProductIndex()
        //{
        //    var products = await _service.FindAllProducts();
        //    return Ok(products);
        //}
        [HttpPost]
        public async Task<ActionResult<Atividade>> Create([FromBody]Atividade atividade)
        {
            
            if (atividade == null) return BadRequest();
            try
            {
                var disciplina = await _disciplina.FindDisciplinaById(atividade.DisciplinaId);
                if(disciplina == null) return BadRequest();

                atividade.Resposta = "";
                atividade.Id = Guid.NewGuid();
                atividade.Concluida = false;
                var newatividade = await _repository.CreateAtividade(atividade);
                disciplina.TarefasId.Add(atividade.Id);
                await _disciplina.UpdateDisciplina(disciplina);
                
                return Ok(newatividade);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            
        }
        [HttpPost("submit/{id}")]
        public async Task<ActionResult<Atividade>> SubmitAtividade([FromBody] SubmitAtividade subAtividade, [FromHeader] Guid id)
        {

            if (subAtividade == null) return BadRequest();
            try
            {
                var sub = await _repository.SubmitAtividade(subAtividade, id);
                var atividade = _repository.FindAtividadeById(id);
                if (atividade.Concluida)
                {
                    Nota nota = new Nota()
                    {
                        AlunoId = atividade.AlunoId,
                        DisciplinaId = atividade.DisciplinaId,
                        AtividadeId = atividade.Id,
                        Id = Guid.NewGuid(),

                    };
                    await _nota.CreateNota(nota);
                }
                return Ok(sub);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
    }
}
