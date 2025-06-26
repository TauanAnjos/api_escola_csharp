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
        /// <summary>
        /// Cria um professor.
        /// </summary>
        /// <param name="request">Dados do professor para criação.</param>
        /// <returns>Retorna um professor criado.</returns>
        [HttpPost]
        public IActionResult CriarProfessor([FromBody] ProfessorDtoRequest request)
        {
            _professorService.CriarProfessor(request);
            return Created("api/v1/professor", request);
        }
        /// <summary>
        /// Cria um professor.
        /// </summary>
        /// <param name="id">ID para buscar professor.</param>
        /// <returns>Retorna um professor referente ao ID.</returns>
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
        /// <summary>
        /// Cria um professor.
        /// </summary>
        /// <param name="id">ID do professor a ser editado.</param>
        /// <param name="request">Dado do professor a ser atualizado.</param>
        /// <returns>Retorna um professor referente ao ID.</returns>
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
        /// <summary>
        /// Deleta um professor.
        /// </summary>
        /// <param name="id">ID do professor a ser deletado.</param>
        /// <returns>Retorna uma mensagem ao deletar professor.</returns>
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
        /// <summary>
        /// Listar professores
        /// </summary>
        /// <returns>Retorna uma lista de professores.</returns>
        [HttpGet]
        public IActionResult ListarProfessores()
        {
            var professorExistentes = _professorService.ListarProfessores();
            return Ok(professorExistentes);
        }
    }
}
