using api_escola.Controllers.Dtos;
using api_escola.Services.IServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace api_escola.Controllers
{
    [ApiController]
    [Route("api/v1/aluno")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _service;
        public AlunoController(IAlunoService service)
        {
            _service = service;
        }
        /// <summary>
        /// Cria um aluno.
        /// </summary>
        /// /// <param name="request">Dados do aluno para criação.</param>
        /// <returns>Retorna um aluno criado</returns>
        [HttpPost]
        public IActionResult CriarAluno([FromBody]AlunoDtoRequest request)
        {
            _service.CriarAluno(request);
            return Created("api/v1/aluno", request);
        }
        /// <summary>
        /// Busca um aluno.
        /// </summary>
        /// /// <param name="id">ID para buscar o aluno.</param>
        /// <returns>Retorna um aluno referente ao ID</returns>
        [HttpGet("{id}")]
        public IActionResult BuscarAlunoPorId([FromRoute]ulong id)
        {
            var alunoExistente = _service.BuscarAluno(id);

            if (alunoExistente == null)
            {
                return NotFound("Aluno de ID: " + id + " não encontrado.");
            }
            return Ok(alunoExistente);
        }
        /// <summary>
        /// Edita os dados de um aluno existente.
        /// </summary>
        /// <param name="id">ID do aluno a ser editado.</param>
        /// <param name="request">Dados atualizados do aluno.</param>
        /// <returns>Retorna o aluno atualizado.</returns>
        [HttpPut("{id}")]
        public IActionResult EditarAluno([FromRoute]ulong id, [FromBody]AlunoDtoRequest request)
        {
            var alunoExistente = _service.BuscarAluno(id);
            if(alunoExistente == null)
            {
                return NotFound("Aluno de ID: " + id + " não encontrado.");
            }
            _service.EditarAluno(id, request);
            var alunoAtualizado = _service.BuscarAluno(id);
            return Ok(alunoAtualizado);
        }
        /// <summary>
        /// Deleta um aluno existente.
        /// </summary>
        /// <param name="id">Deleta um aluno referente ao ID.</param>
        /// <returns>Retorna uma mensagem de sucesso ao deletar aluno.</returns>
        [HttpDelete("{id}")]
        public IActionResult DeletarAluno([FromRoute] ulong id)
        {
            var alunoExistente = _service.BuscarAluno(id);
            if (alunoExistente == null)
            {
                return NotFound("Aluno de ID: " + id + " não encontrado.");
            }
            _service.DeletarAluno(id);
            return Ok("Aluno deletado com sucesso.");
        }
        /// <summary>
        /// Listar alunos.
        /// </summary>
        /// <returns>Retorna uma lista de alunos.</returns>
        [HttpGet]
        public IActionResult BuscarTodosAlunos()
        {
            var listaDeAlunos = _service.ListarAlunos();
            return Ok(listaDeAlunos);
        }
    }
}
