using api_escola.Controllers.Dtos;
using System.Collections.Generic;

namespace api_escola.Services.IServices
{
    public interface ILecionaService
    {
        void CriarLeciona(LecionaDtoRequest request);
        void EditarLeciona(ulong idProfessor, ulong idDisciplina, LecionaDtoRequest request);
        LecionaDtoResponse BuscarLeciona(ulong idProfessor, ulong idDisciplina);
        List<LecionaDtoResponse> ListarLecionas();
        void DeletarLeciona(ulong idProfessor, ulong idDisciplina);
    }
}
