namespace api_escola.Controllers.Dtos
{
    public record ProfessorDtoRequest(
        ulong IdTitulo,
        string TxNome,
        string TxSexo,
        string TxEstadoCivil,
        DateOnly DtNascimento,
        string TxTelefone
    );

}
