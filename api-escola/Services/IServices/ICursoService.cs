using api_escola.Controllers.Dtos;
using System.Collections.Generic;

namespace api_escola.Services.IServices;

public interface ICursoService
{
    void CriarCurso(CursoDtoRequest cursoDtoRequest);
    void EditarCurso(ulong id, CursoDtoRequest cursoDtoRequest);
    CursoDtoResponse BuscarCurso(ulong id);
    List<CursoDtoResponse> ListarCursos();
    void DeletarCurso(ulong id);
}
