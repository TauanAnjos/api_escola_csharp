namespace api_escola.Controllers.Dtos
{
    public record AlunoDtoResponse(
        ulong IdAluno,
        string TxNome,
        string TxSexo,
        DateOnly DtNascimento
    );
}
