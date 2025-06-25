namespace api_escola.Controllers.Dtos
{
    public record DisciplinaDtoRequest(
        ulong IdTipoDisciplina,
        string TxSigla,
        string TxDescricao,
        int InCargaHoraria,
        int InPeriodo
    );
}
