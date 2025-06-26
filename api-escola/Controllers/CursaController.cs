using api_escola.Controllers.Dtos;
using api_escola.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace api_escola.Controllers
{
    [ApiController]
    [Route("api/v1/cursa")]
    public class CursaController : ControllerBase
    {
        private readonly ICursaService _service;

        public CursaController(ICursaService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult CriarCursa([FromBody] CursaDtoRequest request)
        {
            _service.CriarCursa(request);
            return Created("api/v1/cursa", request);
        }

        [HttpGet("{idAluno}/{idDisciplina}")]
        public IActionResult BuscarCursaPorIds([FromRoute] ulong idAluno, [FromRoute] ulong idDisciplina)
        {
            var cursaExistente = _service.BuscarCursa(idAluno, idDisciplina);

            if (cursaExistente == null)
            {
                return NotFound("Vínculo entre aluno " + idAluno + " e  disciplina " + idDisciplina + "não encontrado.");
            }

            return Ok(cursaExistente);
        }

        [HttpPut("{idAluno}/{idDisciplina}")]
        public IActionResult EditarCursa([FromRoute] ulong idAluno, [FromRoute] ulong idDisciplina, [FromBody] CursaDtoRequest request)
        {
            var cursaExistente = _service.BuscarCursa(idAluno, idDisciplina);

            if (cursaExistente == null)
            {
                return NotFound("Vínculo entre aluno " + idAluno + " e  disciplina " + idDisciplina + "não encontrado.");
            }

            _service.EditarCursa(idAluno, idDisciplina, request);

            var cursaAtualizado = _service.BuscarCursa(idAluno, idDisciplina);
            return Ok(cursaAtualizado);
        }

        [HttpDelete("{idAluno}/{idDisciplina}")]
        public IActionResult DeletarCursa([FromRoute] ulong idAluno, [FromRoute] ulong idDisciplina)
        {
            var cursaExistente = _service.BuscarCursa(idAluno, idDisciplina);

            if (cursaExistente == null)
            {
                return NotFound("Vínculo entre aluno " + idAluno + " e  disciplina " + idDisciplina + "não encontrado.");
            }

            _service.DeletarCursa(idAluno, idDisciplina);
            return Ok("Vínculo deletado com sucesso.");
        }

        [HttpGet]
        public IActionResult BuscarTodosCursa()
        {
            var lista = _service.ListarCursa();
            return Ok(lista);
        }
    }
}
