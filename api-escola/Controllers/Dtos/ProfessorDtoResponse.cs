namespace api_escola.Controllers.Dtos
{
    public record ProfessorDtoResponse(
        ulong IdProfessor,
        ulong IdTitulo,
        string TxNome,
        string TxSexo,
        string TxEstadoCivil,
        DateOnly DtNascimento,
        string TxTelefone
    );

}
