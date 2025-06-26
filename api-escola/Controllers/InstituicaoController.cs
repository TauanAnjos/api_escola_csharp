using api_escola.Controllers.Dtos;
using api_escola.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace api_escola.Controllers
{
    [ApiController]
    [Route("api/v1/instituicao")]
    public class InstituicaoController : ControllerBase
    {
        private readonly IInstituicaoService _instituicaoService;

        public InstituicaoController(IInstituicaoService instituicaoService)
        {
            _instituicaoService = instituicaoService;
        }
        /// <summary>
        /// Cria uma instituição.
        /// </summary>
        /// <param name="request">Dados da instituição a ser criada.</param>
        /// <returns>Retorna uma instituição criada.</returns>
        [HttpPost]
        public IActionResult CriarInstituicao([FromBody] InstituicaoDtoRequest request)
        {
            _instituicaoService.CriarInstituicao(request);
            return Created("api/v1/instituicao", request);
        }
        /// <summary>
        /// Busca uma instituição.
        /// </summary>
        /// <param name="id">ID da instituição a ser buscada.</param>
        /// <returns>Retorna uma instituição.</returns>
        [HttpGet("{id}")]
        public IActionResult BuscarInstituicaoPorId([FromRoute] ulong id)
        {
            var instituicao = _instituicaoService.BuscarInstituicao(id);
            if (instituicao == null)
            {
                throw new KeyNotFoundException("Instituição de ID: " + id + " não encontrada");
            }
            return Ok(instituicao);
        }
        /// <summary>
        /// Edita uma instituição.
        /// </summary>
        /// <param name="id">ID da instituição a ser editada</param>
        /// <param name="request">Dados da instituição a ser editada.</param>
        /// <returns>Retorna uma instituição atualizada.</returns>
        [HttpPut("{id}")]
        public IActionResult EditarInstituicao([FromRoute] ulong id, [FromBody] InstituicaoDtoRequest request)
        {
            var instituicaoExistente = _instituicaoService.BuscarInstituicao(id);
            if (instituicaoExistente == null)
            {
                return NotFound("Instituição de ID: " + id + " não encontrada");
            }

            _instituicaoService.EditarInstituicao(id, request);
            var instituicaoAtualizada = _instituicaoService.BuscarInstituicao(id);
            return Ok(instituicaoAtualizada);
        }
        /// <summary>
        /// Deletar uma instituição.
        /// </summary>
        /// <param name="id">ID para deletar uma instituição.</param>
        /// <returns>Retorna uma mensagem de instituição deletada.</returns>
        [HttpDelete("{id}")]
        public IActionResult DeletarInstituicao([FromRoute] ulong id)
        {
            var instituicaoExistente = _instituicaoService.BuscarInstituicao(id);
            if (instituicaoExistente == null)
            {
                return NotFound("Instituição de ID: " + id + " não encontrada");
            }

            _instituicaoService.DeletarInstituicao(id);
            return Ok("Instituição deletada com sucesso.");
        }
        /// <summary>
        /// Listar instituições.
        /// </summary>
        /// <returns>Retorna uma lista de instituições.</returns>
        [HttpGet]
        public IActionResult ListarInstituicoes()
        {
            var instituicoes = _instituicaoService.ListarInstituicoes();
            return Ok(instituicoes);
        }
    }
}
