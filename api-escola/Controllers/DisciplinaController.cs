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
        /// <summary>
        /// Cria uma disciplina
        /// </summary>
        /// <param name="request">Dados referente a disciplina a ser criada</param>
        /// <returns>Retorna uma disciplina criada</returns>
        [HttpPost]
        public IActionResult CriarDisciplina([FromBody] DisciplinaDtoRequest request)
        {
            _disciplinaService.CriarDisciplina(request);
            return Created("api/v1/disciplina", request);
        }
        /// <summary>
        /// Busca uma disciplina
        /// </summary>
        /// <param name="id">ID referente a disciplina a ser buscada</param>
        /// <returns>Retorna a disciplina encontrada referente ao ID</returns>
        [HttpGet("{id}")]
        public IActionResult BuscarDisciplinaPorId([FromRoute] ulong id)
        {
            var disciplina = _disciplinaService.BuscarDisciplina(id);
            return Ok(disciplina);
        }
        /// <summary>
        /// Edita uma disciplina
        /// </summary>
        /// <param name="id">ID referente a disciplina a ser editada</param>
        /// <param name="request">Dados atualizados da disciplina</param>
        /// <returns>Retorna a disciplina atualizada</returns>
        [HttpPut("{id}")]
        public IActionResult EditarDisciplina([FromRoute] ulong id, [FromBody] DisciplinaDtoRequest request)
        {
            _disciplinaService.EditarDisciplina(id, request);
            var disciplinaAtualizada = _disciplinaService.BuscarDisciplina(id);
            return Ok(disciplinaAtualizada);
        }
        /// <summary>
        /// Deleta uma disciplina
        /// </summary>
        /// <param name="id">ID referente a disciplina a ser deletada</param>
        /// <returns>Retorna uma mensagem de sucesso ao deletar disciplina</returns>
        [HttpDelete("{id}")]
        public IActionResult DeletarDisciplina([FromRoute] ulong id)
        {
            _disciplinaService.DeletarDisciplina(id);
            return Ok("Disciplina deletada com sucesso.");
        }
        /// <summary>
        /// Lista disciplinas
        /// </summary>
        /// <returns>Retorna uma lista de disciplinas</returns>
        [HttpGet]
        public IActionResult ListarDisciplinas()
        {
            var disciplinas = _disciplinaService.ListarDisciplinas();
            return Ok(disciplinas);
        }
    }
}
