using api_escola.Controllers.Dtos;

namespace api_escola.Services.IServices
{
    public interface ITipoDisciplinaService
    {
        void CriarTipoDisciplina(TipoDisciplinaDtoRequest tipoDisciplinaDtoRequest);
        void EditarTipoDisciplina(ulong id, TipoDisciplinaDtoRequest tipoDisciplinaDtoRequest);
        TipoDisciplinaDtoResponse BuscarTipoDisciplina(ulong id);
        List<TipoDisciplinaDtoResponse> ListarTiposDisciplina();
        void DeletarTipoDisciplina(ulong id);
    }
}
