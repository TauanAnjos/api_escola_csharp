using api_escola.Controllers.Dtos;

namespace api_escola.Services.IServices
{
    public interface ICursaService
    {
        void CriarCursa(CursaDtoRequest cursaDtoRequest);
        void EditarCursa(ulong id, ulong idDisciplina, CursaDtoRequest cursaDtoRequest);
        CursaDtoResponse BuscarCursa(ulong idAluno, ulong idDiciplina);
        List<CursaDtoResponse> ListarCursa();
        void DeletarCursa(ulong idAluno, ulong idDisciplina);
    }
}
