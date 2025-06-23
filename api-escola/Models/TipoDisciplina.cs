﻿using System;
using System.Collections.Generic;

namespace api_escola.Models;

public partial class TipoDisciplina
{
    public ulong IdTipoDisciplina { get; set; }

    public string TxDescricao { get; set; } = null!;

    public virtual ICollection<Disciplina> Disciplinas { get; set; } = new List<Disciplina>();
}
