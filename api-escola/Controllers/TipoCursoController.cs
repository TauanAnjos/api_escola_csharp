using api_escola.Controllers.Dtos;
using api_escola.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace api_escola.Controllers
{
    [ApiController]
    [Route("api/v1/tipo-curso")]
    public class TipoCursoController : ControllerBase
    {
        private readonly ITipoCursoService _tipoCursoService;

        public TipoCursoController(ITipoCursoService tipoCursoService)
        {
            _tipoCursoService = tipoCursoService;
        }
        /// <summary>
        /// Cria qual o tipo do curso
        /// </summary>
        /// <param name="request">Dados referente ao curso</param>
        /// <returns>Retorna o tipo do curso criado</returns>
        [HttpPost]
        public IActionResult CriarTipoCurso([FromBody] TipoCursoDtoRequest request)
        {
            _tipoCursoService.CriarTipoCurso(request);
            return Created("api/v1/tipo-curso", request);
        }
        /// <summary>
        /// Busca um tipo de curso
        /// </summary>
        /// <param name="id">ID referente ao tipo de curso</param>
        /// <returns>Retorna um curso referente ao ID</returns>
        [HttpGet("{id}")]
        public IActionResult BuscarTipoCursoPorId([FromRoute] ulong id)
        {
            var tipoCurso = _tipoCursoService.BuscarTipoCurso(id);
            if (tipoCurso == null)
            {
                return NotFound("TipoCurso de ID: " + id + " não encontrado");
            }
            return Ok(tipoCurso);
        }
        /// <summary>
        /// Edita um tipo de curso
        /// </summary>
        /// <param name="id">ID referente ao curso a ser editado</param>
        /// <param name="request">Dados a serem atualizados do tipo de curso</param>
        /// <returns>Retorna o tipo de curso atualizado</returns>
        [HttpPut("{id}")]
        public IActionResult EditarTipoCurso([FromRoute] ulong id, [FromBody] TipoCursoDtoRequest request)
        {
            var existente = _tipoCursoService.BuscarTipoCurso(id);
            if (existente == null)
            {
                return NotFound("TipoCurso de ID: " + id + " não encontrado");
            }

            _tipoCursoService.EditarTipoCurso(id, request);
            var atualizado = _tipoCursoService.BuscarTipoCurso(id);
            return Ok(atualizado);
        }
        /// <summary>
        /// Deleta um tipo de curso
        /// </summary>
        /// <param name="id">ID referente ao tipo de curso a ser deletado</param>
        /// <returns>Retorna uma mensagem de sucesso ao deletar tipo de curso</returns>
        [HttpDelete("{id}")]
        public IActionResult DeletarTipoCurso([FromRoute] ulong id)
        {
            var existente = _tipoCursoService.BuscarTipoCurso(id);
            if (existente == null)
            {
                return NotFound("TipoCurso de ID: " + id + " não encontrado");
            }

            _tipoCursoService.DeletarTipoCurso(id);
            return Ok("TipoCurso deletado com sucesso.");
        }
        /// <summary>
        /// Lista tipo de curso
        /// </summary>
        /// <returns>Retorna uma lista de tipos de curso</returns>
        [HttpGet]
        public IActionResult ListarTiposCurso()
        {
            var tiposCurso = _tipoCursoService.ListarTiposCurso();
            return Ok(tiposCurso);
        }
    }
}
