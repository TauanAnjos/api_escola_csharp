using api_escola.Controllers.Dtos;
using api_escola.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace api_escola.Controllers
{
    [ApiController]
    [Route("api/v1/cursa")]
    public class CursaController : ControllerBase
    {
        private readonly ICursaService _service;

        public CursaController(ICursaService service)
        {
            _service = service;
        }
        /// <summary>
        /// Criar um vinculo de Aluno e Disciplina
        /// </summary>
        /// <param name="request">Dados para criar o vinculo</param>
        /// <returns>Retorna um vinculo de aluno e disciplina criado</returns>
        [HttpPost]
        public IActionResult CriarCursa([FromBody] CursaDtoRequest request)
        {
            _service.CriarCursa(request);
            return Created("api/v1/cursa", request);
        }
        /// <summary>
        /// Busca um vinculo
        /// </summary>
        /// <param name="idAluno">ID referente ao aluno</param>
        /// <param name="idDisciplina">ID referente a disciplina</param>
        /// <returns>Retorna um vinculo de aluno e disciplina por ID</returns>
        [HttpGet("{idAluno}/{idDisciplina}")]
        public IActionResult BuscarCursaPorIds([FromRoute] ulong idAluno, [FromRoute] ulong idDisciplina)
        {
            var cursaExistente = _service.BuscarCursa(idAluno, idDisciplina);

            if (cursaExistente == null)
            {
                return NotFound("Vínculo entre aluno " + idAluno + " e  disciplina " + idDisciplina + "não encontrado.");
            }

            return Ok(cursaExistente);
        }
        /// <summary>
        /// Editar um vinculo
        /// </summary>
        /// <param name="idAluno">ID do aluno referente ao vinculo</param>
        /// <param name="idDisciplina">ID da disciplina que o aluno cursa</param>
        /// <param name="request">Dado atualizados do vinculo</param>
        /// <returns>Retorna um vinculo de atualizado</returns>
        [HttpPut("{idAluno}/{idDisciplina}")]
        public IActionResult EditarCursa([FromRoute] ulong idAluno, [FromRoute] ulong idDisciplina, [FromBody] CursaDtoRequest request)
        {
            var cursaExistente = _service.BuscarCursa(idAluno, idDisciplina);

            if (cursaExistente == null)
            {
                return NotFound("Vínculo entre aluno " + idAluno + " e  disciplina " + idDisciplina + "não encontrado.");
            }

            _service.EditarCursa(idAluno, idDisciplina, request);

            var cursaAtualizado = _service.BuscarCursa(idAluno, idDisciplina);
            return Ok(cursaAtualizado);
        }
        /// <summary>
        /// Deleta um vinculo
        /// </summary>
        /// <param name="idAluno">ID do aluno referente ao vinculo</param>
        /// <param name="idDisciplina">ID da disciplina referente ao vinculo</param>
        /// <returns>Retorna uma mensagem de vinculo deletado</returns>
        [HttpDelete("{idAluno}/{idDisciplina}")]
        public IActionResult DeletarCursa([FromRoute] ulong idAluno, [FromRoute] ulong idDisciplina)
        {
            var cursaExistente = _service.BuscarCursa(idAluno, idDisciplina);

            if (cursaExistente == null)
            {
                return NotFound("Vínculo entre aluno " + idAluno + " e  disciplina " + idDisciplina + "não encontrado.");
            }

            _service.DeletarCursa(idAluno, idDisciplina);
            return Ok("Vínculo deletado com sucesso.");
        }
        /// <summary>
        /// Lista vinculos
        /// </summary>
        /// <returns>Retorna uma lista de vinculos entre aluno e disciplina</returns>
        [HttpGet]
        public IActionResult BuscarTodosCursa()
        {
            var lista = _service.ListarCursa();
            return Ok(lista);
        }
    }
}
