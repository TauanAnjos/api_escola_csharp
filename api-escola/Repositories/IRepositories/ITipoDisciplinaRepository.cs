using api_escola.Models;

namespace api_escola.Repositories.IRepositories
{
    public interface ITipoDisciplinaRepository
    {
        void CriarTipoDisciplina(TipoDisciplina tipoDisciplina);
        void EditarTipoDisciplina(TipoDisciplina tipoDisciplina);
        TipoDisciplina? BuscarTipoDisciplina(ulong id);
        List<TipoDisciplina> ListarTiposDisciplina();
        void DeletarTipoDisciplina(TipoDisciplina tipoDisciplina);
    }
}
