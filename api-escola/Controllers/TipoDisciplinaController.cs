using api_escola.Controllers.Dtos;
using api_escola.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace api_escola.Controllers
{
    [ApiController]
    [Route("api/v1/tipo-disciplina")]
    public class TipoDisciplinaController : ControllerBase
    {
        private readonly ITipoDisciplinaService _tipoDisciplinaService;

        public TipoDisciplinaController(ITipoDisciplinaService tipoDisciplinaService)
        {
            _tipoDisciplinaService = tipoDisciplinaService;
        }
        /// <summary>
        /// Cria o tipo da disciplina
        /// </summary>
        /// <param name="request">Dados do tipo da disciplina a ser criada</param>
        /// <returns>Retorna um tipo de disciplina criada.</returns>
        [HttpPost]
        public IActionResult CriarTipoDisciplina([FromBody] TipoDisciplinaDtoRequest request)
        {
            _tipoDisciplinaService.CriarTipoDisciplina(request);
            return Created("api/v1/tipo-disciplina", request);
        }
        /// <summary>
        /// Busca um tipo de disciplina
        /// </summary>
        /// <param name="id">ID referente ao tipo de disciplina a ser buscada</param>
        /// <returns>Retorna o tipo de disciplina encontrado referente ao ID</returns>
        [HttpGet("{id}")]
        public IActionResult BuscarTipoDisciplinaPorId([FromRoute] ulong id)
        {
            var tipo = _tipoDisciplinaService.BuscarTipoDisciplina(id);
            if (tipo == null)
            {
                return NotFound("TipoDisciplina de ID: " + id + " não encontrado");
            }
            return Ok(tipo);
        }
        /// <summary>
        /// Edita um tipo de disciplina
        /// </summary>
        /// <param name="id">ID referente a disciplina a ser editada</param>
        /// <param name="request">Dados para atualizada o tipo de disciplina</param>
        /// <returns>Retorna disciplina atualizada.</returns>
        [HttpPut("{id}")]
        public IActionResult EditarTipoDisciplina([FromRoute] ulong id, [FromBody] TipoDisciplinaDtoRequest request)
        {
            var existente = _tipoDisciplinaService.BuscarTipoDisciplina(id);
            if (existente == null)
            {
                return NotFound("TipoDisciplina de ID: " + id + " não encontrado");
            }

            _tipoDisciplinaService.EditarTipoDisciplina(id, request);
            var atualizado = _tipoDisciplinaService.BuscarTipoDisciplina(id);
            return Ok(atualizado);
        }
        /// <summary>
        /// Deleta tipo de disciplina
        /// </summary>
        /// <param name="id">ID referente a disciplina a ser deletada</param>
        /// <returns>Retorna uma mensagem de sucesso ao deletar tipo de disciplina</returns>
        [HttpDelete("{id}")]
        public IActionResult DeletarTipoDisciplina([FromRoute] ulong id)
        {
            var existente = _tipoDisciplinaService.BuscarTipoDisciplina(id);
            if (existente == null)
            {
                return NotFound("TipoDisciplina de ID: " + id + " não encontrado");
            }

            _tipoDisciplinaService.DeletarTipoDisciplina(id);
            return Ok("TipoDisciplina deletado com sucesso.");
        }
        /// <summary>
        /// Listar tipos de disciplina
        /// </summary>
        /// <returns>Retorna lisa de tipos de disciplina</returns>
        [HttpGet]
        public IActionResult ListarTiposDisciplina()
        {
            var tipos = _tipoDisciplinaService.ListarTiposDisciplina();
            return Ok(tipos);
        }
    }
}
