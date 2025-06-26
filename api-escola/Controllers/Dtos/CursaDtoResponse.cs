namespace api_escola.Controllers.Dtos
{
    public record CursaDtoResponse(
        ulong IdAluno,
        ulong IdDisciplina,
        int InAno,
        int InSemestre,
        int InFaltas,
        decimal? NmNota1,
        decimal? NmNota2,
        decimal? NmNota3,
        bool BlAprovado);
}
