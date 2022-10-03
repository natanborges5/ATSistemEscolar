using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DisciplinaMicro.Model;
using DisciplinaMicro.Repository;
using DisciplinaMicro.Service.AtividadeService;
using DisciplinaMicro.Service.PessoaService;

namespace DisciplinaMicro.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DisciplinaController : ControllerBase
    {
        private IDisciplinaRepository _repository;
        private IAtividadeService _atividade;
        private IAlunoService _aluno;
        private IProfessorService _professor;

        public DisciplinaController(IDisciplinaRepository repository, IAtividadeService atividade,IAlunoService aluno, IProfessorService professor)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _atividade = atividade ?? throw new ArgumentNullException(nameof(atividade));
            _aluno = aluno ?? throw new ArgumentNullException(nameof(aluno));
            _professor = professor;
        }
        [HttpGet]
        public IEnumerable<Disciplina> Get()
        {
            var products =  _repository.ListAllDisciplina();
            return products;
        }
        [HttpGet("{id}")]
        public Disciplina GetById(Guid id)
        {
            var disciplina = _repository.FindDisciplinaById(id);
            return disciplina;
        }
        [HttpPost]
        public async Task<ActionResult<Disciplina>> Create([FromBody] Disciplina disciplina)
        {
            if (disciplina == null) return BadRequest();
            try
            {
                disciplina.Id = Guid.NewGuid();
                var newatividade = await _repository.CreateDisciplina(disciplina);
                foreach(Guid id in disciplina.AlunosId)
                {
                    var aluno = await _aluno.FindAlunoById(id);
                    aluno.DisciplinasId.Add(disciplina.Id);
                    await _aluno.UpdateAluno(aluno);
                }
                var prof = await _professor.FindProfessorById(disciplina.ProfessorId);
                prof.DisciplinasId.Add(disciplina.Id);
                await _professor.UpdateProfessor(prof);
                return Ok(newatividade);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult> Edit([FromBody] Disciplina disciplina)
        {
            if (disciplina == null) return BadRequest();
            var editedProduct = await _repository.UpdateDisciplina(disciplina);
            return Ok(editedProduct);
        }
    }
}