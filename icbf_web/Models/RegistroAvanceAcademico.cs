using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace icbf_web.Models;

public partial class RegistroAvanceAcademico
{
    [Key]
    public int IdAvance { get; set; }

    public long IdNino { get; set; }

    public int AnioEscolarAvance { get; set; }

    public string NivelAvance { get; set; } = null!;

    public string NotaAvance { get; set; } = null!;

    public string DescripcionAvance { get; set; } = null!;

    public DateOnly FechaEntregaAvance { get; set; }

    public virtual Nino IdNinoNavigation { get; set; } = null!;
}
