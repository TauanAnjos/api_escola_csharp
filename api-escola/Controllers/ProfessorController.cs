using api_escola.Controllers.Dtos;
using api_escola.Services.IServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace api_escola.Controllers
{
    [ApiController]
    [Route("api/v1/professor")]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorService _professorService;

        public ProfessorController(IProfessorService professorService)
        {
            _professorService = professorService;
        }
        [HttpPost]
        public IActionResult CriarProfessor([FromBody] ProfessorDtoRequest request)
        {
            _professorService.CriarProfessor(request);
            return Created("api/v1/professor", request);
        }
        [HttpGet("{id}")]
        public IActionResult BuscarProfessorPorId([FromRoute] ulong id)
        {
            var professor = _professorService.BuscarProfessor(id);
            if (professor == null)
            {
                throw new KeyNotFoundException("Professor de ID: " + id + " não encontrado");
            }
            return Ok(professor);
        }
        [HttpPut("{id}")]
        public IActionResult EditarProfessor([FromRoute]ulong id, [FromBody]ProfessorDtoRequest request)
        {
            var professorExistente = _professorService.BuscarProfessor(id);
            if (professorExistente == null)
            {
                return NotFound("Professor de ID: " + id + " não encontrado");
            }
            _professorService.EditarProfessor(id, request);
            var professorAtualizado = _professorService.BuscarProfessor(id);
            return Ok(professorAtualizado);
        }
        [HttpDelete("{id}")]
        public IActionResult DeletarProfessor([FromRoute] ulong id)
        {
            var professorExistente = _professorService.BuscarProfessor(id);
            if (professorExistente == null)
            {
                return NotFound("Professor de ID: " + id + " não encontrado");
            }
            _professorService.DeletarProfessor(id);
            return Ok("Professor deletado com sucesso.");
        }
        [HttpGet]
        public IActionResult ListarProfessores()
        {
            var professorExistentes = _professorService.ListarProfessores();
            return Ok(professorExistentes);
        }
    }
}
