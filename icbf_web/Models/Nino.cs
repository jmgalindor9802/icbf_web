using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace icbf_web.Models;

public partial class Nino
{
    [Key]
    public long IdNino { get; set; }

    public string NombreNino { get; set; } = null!;

    [DataType(DataType.Date)]
    public DateOnly FechaNacimientoNino { get; set; }

    public string TipoSangreNino { get; set; } = null!;

    public string CiudadNacimientoNino { get; set; } = null!;

    public string IdAcudiente { get; set; } = null!;

    public long TelefonoNino { get; set; }

    public string DireccionNino { get; set; } = null!;

    public string EpsNino { get; set; } = null!;

    public int IdJardin { get; set; }

    public virtual Usuario IdAcudienteNavigation { get; set; } = null!;

    public virtual Jardin IdJardinNavigation { get; set; } = null!;

    public virtual ICollection<RegistroAsistencia> RegistrosAsistencia { get; set; } = new List<RegistroAsistencia>();

    public virtual ICollection<RegistroAvanceAcademico> RegistrosAvanceAcademicos { get; set; } = new List<RegistroAvanceAcademico>();
}
