namespace api_escola.Controllers.Dtos
{
    public record InstituicaoDtoResponse(
        ulong IdInstituicao,
        string TxSigla,
        string TxDescricao
    );
}
