using api_escola.Controllers.Dtos;

namespace api_escola.Services.IServices
{
    public interface ITituloService
    {
        void CriarTitulo(TituloDtoRequest tituloDtoRequest);
        void EditarTitulo(ulong id, TituloDtoRequest tituloDtoRequest);
        TituloDtoResponse BuscarTitulo(ulong id);
        List<TituloDtoResponse> ListarTitulos();
        void DeletarTitulo(ulong id);
    }
}
