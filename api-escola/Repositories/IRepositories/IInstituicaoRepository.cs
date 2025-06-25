using api_escola.Models;

namespace api_escola.Repositories.IRepositories
{
    public interface IInstituicaoRepository
    {
        void CriarInstituicao(Instituicao instituicao);
        void EditarInstituicao(Instituicao instituicao);
        Instituicao? BuscarInstituicao(ulong id);
        List<Instituicao> ListarInstituicoes();
        void DeletarInstituicao(Instituicao instituicao);
    }
}
