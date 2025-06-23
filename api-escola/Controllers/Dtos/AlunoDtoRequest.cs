namespace api_escola.Controllers.Dtos
{
    public record AlunoDtoRequest(
        string TxNome,
        string TxSexo,
        DateOnly DtNascimento
    );
}
