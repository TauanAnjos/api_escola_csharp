using api_escola.Controllers.Dtos;

namespace api_escola.Services.IServices
{
    public interface IProfessorService
    {
        void CriarProfessor(ProfessorDtoRequest professorDtoRequest);
        void EditarProfessor(ulong id, ProfessorDtoRequest professorDtoRequest);
        ProfessorDtoResponse BuscarProfessor(ulong id);
        List<ProfessorDtoResponse> ListarProfessores();
        void DeletarProfessor(ulong id);
    }
}
