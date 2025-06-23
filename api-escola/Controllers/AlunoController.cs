using api_escola.Controllers.Dtos;
using api_escola.Services.IServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace api_escola.Controllers
{
    [ApiController]
    [Route("api/v1/aluno")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _service;
        public AlunoController(IAlunoService service)
        {
            _service = service;
        }
        [HttpPost]
        public IActionResult CriarAluno([FromBody]AlunoDtoRequest request)
        {
            _service.CriarAluno(request);
            return Created("api/v1/aluno", request);
        }
        [HttpGet("{id}")]
        public IActionResult BuscarAlunoPorId([FromRoute]ulong id)
        {
            var alunoExistente = _service.BuscarAluno(id);

            if (alunoExistente == null)
            {
                return NotFound("Cliente de ID: " + id + " não encontrado.");
            }
            return Ok(alunoExistente);
        }
        [HttpPut("{id}")]
        public IActionResult EditarAluno([FromRoute]ulong id, [FromBody]AlunoDtoRequest request)
        {
            var alunoExistente = _service.BuscarAluno(id);
            if(alunoExistente == null)
            {
                return NotFound("Cliente de ID: " + id + " não encontrado.");
            }
            _service.EditarAluno(id, request);
            var alunoAtualizado = _service.BuscarAluno(id);
            return Ok(alunoAtualizado);
        }
        [HttpDelete("{id}")]
        public IActionResult DeletarAluno([FromRoute] ulong id)
        {
            var alunoExistente = _service.BuscarAluno(id);
            if (alunoExistente == null)
            {
                return NotFound("Cliente de ID: " + id + " não encontrado.");
            }
            _service.DeletarAluno(id);
            return Ok("Aluno deletado com sucesso.");
        }
    }
}
