using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace icbf_web.Models;

public partial class RegistroAsistencia
{
    [Key]  
    public int IdRegistroAsistencia { get; set; }
    [Required(ErrorMessage = "Campo obligatorio")]
    [Display(Name = "NUIP")]
    public long IdNino { get; set; }

    [Display(Name = "Fecha Registro")]
    public DateTime FechaRegistro { get; set; }
    [Required(ErrorMessage = "Campo obligatorio")]
    [Display(Name = "Estado")]
    public string EstadoNinoRegistro { get; set; } = null!;

    public virtual Nino IdNinoNavigation { get; set; } = null!;

    public RegistroAsistencia()
    {
        FechaRegistro = DateTime.Now;
    }
}
