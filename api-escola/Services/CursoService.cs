using api_escola.Controllers.Dtos;
using api_escola.Models;
using api_escola.Repositories.IRepositories;
using api_escola.Services.IServices;
using AutoMapper;
using System.Collections.Generic;

namespace api_escola.Services;

public class CursoService : ICursoService
{
    private readonly ICursoRepository _cursoRepository;
    private readonly IMapper _mapper;

    public CursoService(ICursoRepository cursoRepository, IMapper mapper)
    {
        _cursoRepository = cursoRepository;
        _mapper = mapper;
    }

    public CursoDtoResponse BuscarCurso(ulong id)
    {
        var curso = _cursoRepository.BuscarCurso(id);
        if (curso == null)
        {
            throw new KeyNotFoundException("Curso de ID: " + id + " não encontrado");
        }
        return _mapper.Map<CursoDtoResponse>(curso);
    }

    public void CriarCurso(CursoDtoRequest cursoDtoRequest)
    {
        if (cursoDtoRequest == null)
        {
            throw new ArgumentNullException("Dados do curso são obrigatórios");
        }
        var curso = _mapper.Map<Curso>(cursoDtoRequest);
        _cursoRepository.CriarCurso(curso);
    }

    public void DeletarCurso(ulong id)
    {
        var curso = _cursoRepository.BuscarCurso(id);
        if (curso == null)
        {
            throw new KeyNotFoundException("Curso de ID: " + id + " não encontrado");
        }
        _cursoRepository.DeletarCurso(curso);
    }

    public void EditarCurso(ulong id, CursoDtoRequest cursoDtoRequest)
    {
        var curso = _cursoRepository.BuscarCurso(id);
        if (curso == null)
        {
            throw new KeyNotFoundException("Curso de ID: " + id + " não encontrado");
        }
        _mapper.Map(cursoDtoRequest, curso);
        _cursoRepository.EditarCurso(curso);
    }

    public List<CursoDtoResponse> ListarCursos()
    {
        var cursos = _cursoRepository.ListarCursos();
        return _mapper.Map<List<CursoDtoResponse>>(cursos);
    }
}
