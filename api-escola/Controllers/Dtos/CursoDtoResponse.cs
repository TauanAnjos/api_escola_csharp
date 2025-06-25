namespace api_escola.Controllers.Dtos;

public record CursoDtoResponse(
    ulong IdCurso,
    ulong IdInstituicao,
    ulong IdTipoCurso,
    string TxDescricao);
