﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace icbf_web.Models;

public partial class RegistroAsistencia
{
    [Key]
    public int IdRegistroAsistencia { get; set; }

    public long IdNino { get; set; }

    public DateOnly FechaRegistro { get; set; }

    public string EstadoNinoRegistro { get; set; } = null!;

    public virtual Nino IdNinoNavigation { get; set; } = null!;
}
