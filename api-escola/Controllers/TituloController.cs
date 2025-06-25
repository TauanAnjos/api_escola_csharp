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

        [HttpPost]
        public IActionResult CriarTitulo([FromBody] TituloDtoRequest request)
        {
            _tituloService.CriarTitulo(request);
            return Created("api/v1/titulo", request);
        }

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

        [HttpGet]
        public IActionResult ListarTitulos()
        {
            var titulos = _tituloService.ListarTitulos();
            return Ok(titulos);
        }
    }
}
