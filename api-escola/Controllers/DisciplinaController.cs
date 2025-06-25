using api_escola.Controllers.Dtos;
using api_escola.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace api_escola.Controllers
{
    [ApiController]
    [Route("api/v1/disciplina")]
    public class DisciplinaController : ControllerBase
    {
        private readonly IDisciplinaService _disciplinaService;

        public DisciplinaController(IDisciplinaService disciplinaService)
        {
            _disciplinaService = disciplinaService;
        }

        [HttpPost]
        public IActionResult CriarDisciplina([FromBody] DisciplinaDtoRequest request)
        {
            _disciplinaService.CriarDisciplina(request);
            return Created("api/v1/disciplina", request);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarDisciplinaPorId([FromRoute] ulong id)
        {
            var disciplina = _disciplinaService.BuscarDisciplina(id);
            return Ok(disciplina);
        }

        [HttpPut("{id}")]
        public IActionResult EditarDisciplina([FromRoute] ulong id, [FromBody] DisciplinaDtoRequest request)
        {
            _disciplinaService.EditarDisciplina(id, request);
            var disciplinaAtualizada = _disciplinaService.BuscarDisciplina(id);
            return Ok(disciplinaAtualizada);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarDisciplina([FromRoute] ulong id)
        {
            _disciplinaService.DeletarDisciplina(id);
            return Ok("Disciplina deletada com sucesso.");
        }

        [HttpGet]
        public IActionResult ListarDisciplinas()
        {
            var disciplinas = _disciplinaService.ListarDisciplinas();
            return Ok(disciplinas);
        }
    }
}
