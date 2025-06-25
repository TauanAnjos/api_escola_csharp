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

        [HttpPost]
        public IActionResult CriarInstituicao([FromBody] InstituicaoDtoRequest request)
        {
            _instituicaoService.CriarInstituicao(request);
            return Created("api/v1/instituicao", request);
        }

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

        [HttpGet]
        public IActionResult ListarInstituicoes()
        {
            var instituicoes = _instituicaoService.ListarInstituicoes();
            return Ok(instituicoes);
        }
    }
}
