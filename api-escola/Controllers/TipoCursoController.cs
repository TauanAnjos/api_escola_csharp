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

        [HttpPost]
        public IActionResult CriarTipoCurso([FromBody] TipoCursoDtoRequest request)
        {
            _tipoCursoService.CriarTipoCurso(request);
            return Created("api/v1/tipo-curso", request);
        }

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

        [HttpGet]
        public IActionResult ListarTiposCurso()
        {
            var tiposCurso = _tipoCursoService.ListarTiposCurso();
            return Ok(tiposCurso);
        }
    }
}
