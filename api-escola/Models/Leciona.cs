namespace api_escola.Models;

public class Leciona
{
    public ulong IdProfessor { get; set; }
    public ulong IdDisciplina { get; set; }

    public virtual Professor Professor { get; set; }
    public virtual Disciplina Disciplina { get; set; }
}
