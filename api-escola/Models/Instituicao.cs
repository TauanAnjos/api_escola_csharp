using System;
using System.Collections.Generic;

namespace api_escola.Models;

public partial class Instituicao
{
    public ulong IdInstituicao { get; set; }

    public string TxSigla { get; set; } = null!;

    public string TxDescricao { get; set; } = null!;

    public virtual ICollection<Curso> Cursos { get; set; } = new List<Curso>();
}
