using api_escola.Controllers.Dtos;

namespace api_escola.Services.IServices
{
    public interface ITipoCursoService
    {
        void CriarTipoCurso(TipoCursoDtoRequest tipoCursoDtoRequest);
        void EditarTipoCurso(ulong id, TipoCursoDtoRequest tipoCursoDtoRequest);
        TipoCursoDtoResponse BuscarTipoCurso(ulong id);
        List<TipoCursoDtoResponse> ListarTiposCurso();
        void DeletarTipoCurso(ulong id);
    }
}
