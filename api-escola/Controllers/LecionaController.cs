using api_escola.Controllers.Dtos;
using api_escola.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace api_escola.Controllers
{
    [ApiController]
    [Route("api/v1/leciona")]
    public class LecionaController : ControllerBase
    {
        private readonly ILecionaService _service;

        public LecionaController(ILecionaService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult CriarLeciona([FromBody] LecionaDtoRequest request)
        {
            _service.CriarLeciona(request);
            return Created("api/v1/leciona", request);
        }

        [HttpGet("{idProfessor}/{idDisciplina}")]
        public IActionResult BuscarLecionaPorId([FromRoute] ulong idProfessor, [FromRoute] ulong idDisciplina)
        {
            var lecionaExistente = _service.BuscarLeciona(idProfessor, idDisciplina);

            if (lecionaExistente == null)
            {
                return NotFound("Leciona do Professor" + idProfessor + " e Disciplina " + idDisciplina + "não encontrado.");
            }

            return Ok(lecionaExistente);
        }

        [HttpPut("{idProfessor}/{idDisciplina}")]
        public IActionResult EditarLeciona([FromRoute] ulong idProfessor, [FromRoute] ulong idDisciplina, [FromBody] LecionaDtoRequest request)
        {
            var lecionaExistente = _service.BuscarLeciona(idProfessor, idDisciplina);

            if (lecionaExistente == null)
            {
                return NotFound("Leciona do Professor" + idProfessor + " e Disciplina " + idDisciplina + "não encontrado.");
            }

            _service.EditarLeciona(idProfessor, idDisciplina, request);

            var lecionaAtualizado = _service.BuscarLeciona(idProfessor, idDisciplina);
            return Ok(lecionaAtualizado);
        }

        [HttpDelete("{idProfessor}/{idDisciplina}")]
        public IActionResult DeletarLeciona([FromRoute] ulong idProfessor, [FromRoute] ulong idDisciplina)
        {
            var lecionaExistente = _service.BuscarLeciona(idProfessor, idDisciplina);

            if (lecionaExistente == null)
            {
                return NotFound("Leciona do Professor" + idProfessor + " e Disciplina " + idDisciplina  +"não encontrado.");
            }

            _service.DeletarLeciona(idProfessor, idDisciplina);
            return Ok("Leciona deletado com sucesso.");
        }

        [HttpGet]
        public IActionResult BuscarTodosLecionas()
        {
            var listaDeLecionas = _service.ListarLecionas();
            return Ok(listaDeLecionas);
        }
    }
}
