using api_escola.Models;

namespace api_escola.Repositories.IRepositories
{
    public interface ICursaRepository
    {
        void CriarCursa(Cursa cursa);
        void EditarCursa(Cursa cursa);
        Cursa? BuscarCursa(ulong idAluno,ulong idDisciplina);
        List<Cursa> ListarCursa();
        void DeletarCursa(Cursa cursa);
    }
}
