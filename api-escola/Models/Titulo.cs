using System;
using System.Collections.Generic;

namespace api_escola.Models;

public partial class Titulo
{
    public ulong IdTitulo { get; set; }

    public string TxDescricao { get; set; } = null!;

    public virtual ICollection<Professor> Professors { get; set; } = new List<Professor>();
}
