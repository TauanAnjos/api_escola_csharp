using api_escola.Models;

namespace api_escola.Repositories.IRepositories
{
    public interface IAlunoRepository
    {
        void CadastrarAluno(Aluno aluno);
        void EditarAluno(Aluno aluno);
        Aluno? BuscarAluno(ulong id);
        List<Aluno> ListarAlunos();
        void DeletarAluno(Aluno aluno);
    }
}
