using api_escola.Controllers.Dtos;

namespace api_escola.Services.IServices
{
    public interface IInstituicaoService
    {
        void CriarInstituicao(InstituicaoDtoRequest instituicaoDtoRequest);
        void EditarInstituicao(ulong id, InstituicaoDtoRequest instituicaoDtoRequest);
        InstituicaoDtoResponse BuscarInstituicao(ulong id);
        List<InstituicaoDtoResponse> ListarInstituicoes();
        void DeletarInstituicao(ulong id);
    }
}
