namespace api_escola.Controllers.Dtos
{
    public record LecionaDtoRequest(
        ulong IdProfessor,
        ulong IdDisciplina
    );
}
