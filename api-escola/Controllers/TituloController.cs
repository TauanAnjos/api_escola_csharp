using api_escola.Controllers.Dtos;
using api_escola.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace api_escola.Controllers
{
    [ApiController]
    [Route("api/v1/titulo")]
    public class TituloController : ControllerBase
    {
        private readonly ITituloService _tituloService;

        public TituloController(ITituloService tituloService)
        {
            _tituloService = tituloService;
        }
        /// <summary>
        /// Cria um titulo
        /// </summary>
        /// <param name="request">Dado do titulo a ser criado</param>
        /// <returns>Retorna um titulo criado</returns>
        [HttpPost]
        public IActionResult CriarTitulo([FromBody] TituloDtoRequest request)
        {
            _tituloService.CriarTitulo(request);
            return Created("api/v1/titulo", request);
        }
        /// <summary>
        /// Busca um titulo
        /// </summary>
        /// <param name="id">ID do titulo a ser buscado</param>
        /// <returns>Retorna titulo encontrado referente ao ID</returns>
        [HttpGet("{id}")]
        public IActionResult BuscarTituloPorId([FromRoute] ulong id)
        {
            var titulo = _tituloService.BuscarTitulo(id);
            if (titulo == null)
            {
                return NotFound("Título de ID: " + id + " não encontrado");
            }
            return Ok(titulo);
        }
        /// <summary>
        /// Edita um titulo
        /// </summary>
        /// <param name="id">ID do titulo a ser editado</param>
        /// <param name="request">Dado para atualizar o titulo</param>
        /// <returns>Retorna um titulo atualizado</returns>
        [HttpPut("{id}")]
        public IActionResult EditarTitulo([FromRoute] ulong id, [FromBody] TituloDtoRequest request)
        {
            var tituloExistente = _tituloService.BuscarTitulo(id);
            if (tituloExistente == null)
            {
                return NotFound("Título de ID: " + id + " não encontrado");
            }

            _tituloService.EditarTitulo(id, request);
            var tituloAtualizado = _tituloService.BuscarTitulo(id);
            return Ok(tituloAtualizado);
        }
        /// <summary>
        /// Deleta um titulo
        /// </summary>
        /// <param name="id">ID referente ao titulo a ser deletado</param>
        /// <returns>Retorna uma mensagem de sucesso ao deletar o titulo</returns>
        [HttpDelete("{id}")]
        public IActionResult DeletarTitulo([FromRoute] ulong id)
        {
            var tituloExistente = _tituloService.BuscarTitulo(id);
            if (tituloExistente == null)
            {
                return NotFound("Título de ID: " + id + " não encontrado");
            }

            _tituloService.DeletarTitulo(id);
            return Ok("Título deletado com sucesso.");
        }
        /// <summary>
        /// Lista titulos
        /// </summary>
        /// <returns>Retorna uma lista de titulos</returns>
        [HttpGet]
        public IActionResult ListarTitulos()
        {
            var titulos = _tituloService.ListarTitulos();
            return Ok(titulos);
        }
    }
}
