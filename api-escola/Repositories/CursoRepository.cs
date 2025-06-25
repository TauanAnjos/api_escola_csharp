using api_escola.Models;
using api_escola.Repositories.IRepositories;
using System.Linq;
using System.Collections.Generic;

namespace api_escola.Repositories;

public class CursoRepository : ICursoRepository
{
    private readonly ProjetoP3Context _context;

    public CursoRepository(ProjetoP3Context context)
    {
        _context = context;
    }

    public Curso? BuscarCurso(ulong id)
    {
        return _context.Set<Curso>().FirstOrDefault(c => c.IdCurso == id);
    }

    public void CriarCurso(Curso curso)
    {
        _context.Cursos.Add(curso);
        _context.SaveChanges();
    }

    public void DeletarCurso(Curso curso)
    {
        _context.Cursos.Remove(curso);
        _context.SaveChanges();
    }

    public void EditarCurso(Curso curso)
    {
        _context.Cursos.Update(curso);
        _context.SaveChanges();
    }

    public List<Curso> ListarCursos()
    {
        return _context.Cursos.ToList();
    }
}
