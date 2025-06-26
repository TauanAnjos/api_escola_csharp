using api_escola.Models;
using System.Collections.Generic;

namespace api_escola.Repositories.IRepositories
{
    public interface ILecionaRepository
    {
        void CadastrarLeciona(Leciona leciona);
        void EditarLeciona(Leciona leciona);
        Leciona? BuscarLeciona(ulong idProfessor, ulong idDisciplina);
        List<Leciona> ListarLecionas();
        void DeletarLeciona(Leciona leciona);
    }
}
