using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PessoasMicro.Model;
using PessoasMicro.Repository.ProfessorRepository;
using System.Data;

namespace PessoasMicro.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProfessorController : Controller
    {
        private IProfessorRepository _repository;

        public ProfessorController(IProfessorRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));

        }
        [HttpGet]
        public IEnumerable<Professor> Get()
        {
            var products = _repository.ListAllProfessor();
            return products;
        }
        [HttpGet("{id}")]
        public Professor GetById(Guid id)
        {
            var disciplina = _repository.FindProfessorById(id);
            return disciplina;
        }
        [HttpPost]
        public async Task<ActionResult<Professor>> Create([FromBody] Professor professor)
        {
            if (professor == null) return BadRequest();
            try
            {
                professor.Id = Guid.NewGuid();
                var newatividade = await _repository.CreateProfessor(professor);
                return Ok(newatividade);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult> Edit([FromBody] Professor professor)
        {
            if (professor == null && _repository.FindProfessorById(professor.Id) == null) return BadRequest();
            try
            {
                var editedProduct = await _repository.UpdateProfessor(professor);
                return Ok(editedProduct);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var status = await _repository.DeleteProfessor(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}
