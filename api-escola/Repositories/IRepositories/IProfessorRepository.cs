using api_escola.Models;

namespace api_escola.Repositories.IRepositories
{
    public interface IProfessorRepository
    {
        void CriarProfessor(Professor professor);
        void EditarProfessor(Professor professor);
        Professor? BuscarProfessor(ulong id);
        List<Professor> ListarProfessores();
        void DeleteProfessor(Professor professor);
    }
}
