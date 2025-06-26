﻿using System;
using System.Collections.Generic;

namespace api_escola.Models;

public partial class Professor
{
    public ulong IdProfessor { get; set; }

    public ulong IdTitulo { get; set; }

    public string TxNome { get; set; } = null!;

    public string TxSexo { get; set; } = null!;

    public string TxEstadoCivil { get; set; } = null!;

    public DateOnly DtNascimento { get; set; }

    public string TxTelefone { get; set; } = null!;

    public virtual Titulo IdTituloNavigation { get; set; } = null!;

    public virtual ICollection<Leciona> Lecionas { get; set; } = new List<Leciona>();
}
