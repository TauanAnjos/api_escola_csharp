using api_escola.Models;
using System.Collections.Generic;

namespace api_escola.Repositories.IRepositories;

public interface ICursoRepository
{
    void CriarCurso(Curso curso);
    void EditarCurso(Curso curso);
    Curso? BuscarCurso(ulong id);
    List<Curso> ListarCursos();
    void DeletarCurso(Curso curso);
}
