using api_escola.Models;

namespace api_escola.Repositories.IRepositories
{
    public interface IDisciplinaRepository
    {
        void CriarDisciplina(Disciplina disciplina);
        void EditarDisciplina(Disciplina disciplina);
        Disciplina? BuscarDisciplina(ulong id);
        List<Disciplina> ListarDisciplinas();
        void DeletarDisciplina(Disciplina disciplina);
    }
}
