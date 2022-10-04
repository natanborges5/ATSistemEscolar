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
        [HttpPost]
        public async Task<ActionResult<Atividade>> Create([FromBody]Atividade atividade)
        {
            
            if (atividade == null) return BadRequest();
            try
            {
                var disciplina = await _disciplina.FindDisciplinaById(atividade.DisciplinaId);
                if(disciplina == null) return BadRequest();

                
                foreach(Guid idAluno in disciplina.AlunosId)
                {
                    var newAtividade = new Atividade();
                    newAtividade.Id = Guid.NewGuid();
                    newAtividade.Enunciado = atividade.Enunciado;
                    newAtividade.DataSubmissao = DateTime.Today;
                    newAtividade.Prazo = atividade.Prazo;

                    newAtividade.AlunoId = idAluno;
                    newAtividade.DisciplinaId = disciplina.Id;
                    newAtividade.Resposta = "";
                    newAtividade.Concluida = false;
                    await _repository.CreateAtividade(newAtividade);
                    disciplina.TarefasId.Add(newAtividade.Id);
                    await _disciplina.UpdateDisciplina(disciplina);
                }             
                return Ok();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("submit/{id}")]
        public async Task<ActionResult<Atividade>> SubmitAtividade([FromBody] SubmitAtividade subAtividade, Guid id)
        {
            Nota nota2 = new Nota();
            await _nota.CreateNota(nota2);
            if (subAtividade == null) return BadRequest();
            try
            {
                var atividade = await _repository.SubmitAtividade(subAtividade, id);
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
                    Random notaAleatoria = new Random();
                    notaAleatoria.Next(1, 10);
                    //_repository.ProducerRabbit(notaAleatoria.ToString());
                    await _nota.UpdateNota(nota);

                }
                return Ok(atividade);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
    }
}
