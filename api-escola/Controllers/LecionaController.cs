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
        /// <summary>
        /// Cria um vinculo entre professor e disciplina lecionada
        /// </summary>
        /// <param name="request">Dados do professor e da disciplina</param>
        /// <returns>Retorna um vinculo de lecionamento criado</returns>
        [HttpPost]
        public IActionResult CriarLeciona([FromBody] LecionaDtoRequest request)
        {
            _service.CriarLeciona(request);
            return Created("api/v1/leciona", request);
        }
        /// <summary>
        /// Busca vinculo de lecionamento
        /// </summary>
        /// <param name="idProfessor">ID do professor referente ao vinculo</param>
        /// <param name="idDisciplina">ID da disciplina referente ao vinculo</param>
        /// <returns>Retorna um vinculo de lecionamento</returns>
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
        /// <summary>
        /// Editar leciona
        /// </summary>
        /// <param name="idProfessor"> ID referente ao professor</param>
        /// <param name="idDisciplina">ID da disciplina referente ao vinculo com professor</param>
        /// <param name="request">Dados atualizados do vinculo de lecionamento</param>
        /// <returns>Retorna o vinculo de lecionamento atualizado</returns>
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
        /// <summary>
        /// Deleta um vinculo de lecionamento
        /// </summary>
        /// <param name="idProfessor">ID do professor </param>
        /// <param name="idDisciplina">ID da disciplina </param>
        /// <returns>Retorna uma mensagem de vinculo de lecionamento deletado</returns>
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
        /// <summary>
        /// Lista vinculos de lecionamento
        /// </summary>
        /// <returns>Retorna uma lista de vinculos de lecionamento</returns>
        [HttpGet]
        public IActionResult BuscarTodosLecionas()
        {
            var listaDeLecionas = _service.ListarLecionas();
            return Ok(listaDeLecionas);
        }
    }
}
