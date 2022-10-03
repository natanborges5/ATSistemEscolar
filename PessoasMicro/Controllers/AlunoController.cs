using Microsoft.AspNetCore.Mvc;
using PessoasMicro.Model;
using PessoasMicro.Repository.AlunoRepository;

namespace PessoasMicro.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AlunoController : Controller
    {
        private IAlunoRepository _repository;

        public AlunoController(IAlunoRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));

        }
        [HttpGet]
        public IEnumerable<Aluno> Get()
        {
            var alunos = _repository.ListAllAlunos();
            return alunos;
        }
        [HttpGet("{id}")]
        public Aluno GetById(Guid id)
        {
            var aluno = _repository.FindAlunoById(id);
            return aluno;
        }
        [HttpPost]
        public async Task<ActionResult<Aluno>> Create([FromBody] Aluno aluno)
        {
            if (aluno == null) return BadRequest();
            try
            {
                aluno.Id = Guid.NewGuid();
                var newatividade = await _repository.CreateAluno(aluno);
                return Ok(newatividade);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult> Edit([FromBody] Aluno aluno)
        {
            if (aluno == null && _repository.FindAlunoById(aluno.Id) == null) return BadRequest();
            try
            {
                var editedProduct = await _repository.UpdateAluno(aluno);
                return Ok(editedProduct);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var status = await _repository.DeleteAluno(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}
