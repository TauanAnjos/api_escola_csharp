using api_escola.Models;

namespace api_escola.Repositories.IRepositories
{
    public interface ITipoCursoRepository
    {
        void CriarTipoCurso(TipoCurso tipoCurso);
        void EditarTipoCurso(TipoCurso tipoCurso);
        TipoCurso? BuscarTipoCurso(ulong id);
        List<TipoCurso> ListarTiposCurso();
        void DeletarTipoCurso(TipoCurso tipoCurso);
    }
}
