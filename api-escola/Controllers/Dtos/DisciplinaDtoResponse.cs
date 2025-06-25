namespace api_escola.Controllers.Dtos
{
    public record DisciplinaDtoResponse(
        ulong IdDisciplina,
        ulong? IdCurso,
        ulong IdTipoDisciplina,
        string TxSigla,
        string TxDescricao,
        int InCargaHoraria,
        int InPeriodo
    );
}
