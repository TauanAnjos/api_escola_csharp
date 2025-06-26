using api_escola.Controllers.Dtos;
using api_escola.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace api_escola.Controllers;

[ApiController]
[Route("api/v1/curso")]
public class CursoController : ControllerBase
{
    private readonly ICursoService _cursoService;

    public CursoController(ICursoService cursoService)
    {
        _cursoService = cursoService;
    }
    /// <summary>
    /// Cria um cruso
    /// </summary>
    /// <param name="request">Dados do curso a ser criado</param>
    /// <returns>Retorna um curso criado</returns>
    [HttpPost]
    public IActionResult CriarCurso([FromBody] CursoDtoRequest request)
    {
        _cursoService.CriarCurso(request);
        return Created("api/v1/curso", request);
    }
    /// <summary>
    /// Busca um curso
    /// </summary>
    /// <param name="id">ID do curso a ser buscado</param>
    /// <returns>Retorna um curso encontrado referente ao ID</returns>
    [HttpGet("{id}")]
    public IActionResult BuscarCursoPorId([FromRoute] ulong id)
    {
        var curso = _cursoService.BuscarCurso(id);
        if (curso == null)
        {
            return NotFound("Curso de ID: " + id + " não encontrado");
        }
        return Ok(curso);
    }
    /// <summary>
    /// Edita um curso
    /// </summary>
    /// <param name="id">ID do curso a ser editado</param>
    /// <param name="request">Dados atualizados do curso</param>
    /// <returns>Retorna um curso atualizado</returns>
    [HttpPut("{id}")]
    public IActionResult EditarCurso([FromRoute] ulong id, [FromBody] CursoDtoRequest request)
    {
        var cursoExistente = _cursoService.BuscarCurso(id);
        if (cursoExistente == null)
        {
            return NotFound("Curso de ID: " + id + " não encontrado");
        }

        _cursoService.EditarCurso(id, request);
        var cursoAtualizado = _cursoService.BuscarCurso(id);
        return Ok(cursoAtualizado);
    }
    /// <summary>
    /// Deleta um curso
    /// </summary>
    /// <param name="id">ID referente ao curso a ser deletado</param>
    /// <returns>Retorna uma mensagem de sucesso ao deletar o curso</returns>
    [HttpDelete("{id}")]
    public IActionResult DeletarCurso([FromRoute] ulong id)
    {
        var cursoExistente = _cursoService.BuscarCurso(id);
        if (cursoExistente == null)
        {
            return NotFound("Curso de ID: " + id + " não encontrado");
        }

        _cursoService.DeletarCurso(id);
        return Ok("Curso deletado com sucesso.");
    }
    /// <summary>
    /// Lista cursos
    /// </summary>
    /// <returns>Retorna uma lista de cursos</returns>
    [HttpGet]
    public IActionResult ListarCursos()
    {
        var cursos = _cursoService.ListarCursos();
        return Ok(cursos);
    }
}
