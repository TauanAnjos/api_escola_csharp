using api_escola.Controllers.Dtos;

namespace api_escola.Services.IServices
{
    public interface IAlunoService
    {
        void CriarAluno(AlunoDtoRequest request);
        void EditarAluno(ulong id, AlunoDtoRequest request);
        AlunoDtoResponse BuscarAluno(ulong id);
        List<AlunoDtoResponse> List();
        void DeletarAluno(ulong id);
    }
}
