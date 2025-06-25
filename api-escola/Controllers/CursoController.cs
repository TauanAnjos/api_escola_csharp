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

    [HttpPost]
    public IActionResult CriarCurso([FromBody] CursoDtoRequest request)
    {
        _cursoService.CriarCurso(request);
        return Created("api/v1/curso", request);
    }

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

    [HttpGet]
    public IActionResult ListarCursos()
    {
        var cursos = _cursoService.ListarCursos();
        return Ok(cursos);
    }
}
