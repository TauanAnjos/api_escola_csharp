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

        [HttpPost]
        public IActionResult CriarTipoDisciplina([FromBody] TipoDisciplinaDtoRequest request)
        {
            _tipoDisciplinaService.CriarTipoDisciplina(request);
            return Created("api/v1/tipo-disciplina", request);
        }

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

        [HttpGet]
        public IActionResult ListarTiposDisciplina()
        {
            var tipos = _tipoDisciplinaService.ListarTiposDisciplina();
            return Ok(tipos);
        }
    }
}
