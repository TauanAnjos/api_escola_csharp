using api_escola.Controllers.Dtos;

namespace api_escola.Services.IServices
{
    public interface IDisciplinaService
    {
        void CriarDisciplina(DisciplinaDtoRequest disciplinaDtoRequest);
        void EditarDisciplina(ulong id, DisciplinaDtoRequest disciplinaDtoRequest);
        DisciplinaDtoResponse BuscarDisciplina(ulong id);
        List<DisciplinaDtoResponse> ListarDisciplinas();
        void DeletarDisciplina(ulong id);
    }
}
