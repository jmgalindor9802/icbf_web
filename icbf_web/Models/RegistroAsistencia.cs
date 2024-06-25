using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace icbf_web.Models;

public partial class RegistroAsistencia
{
    [Key]  
    public int IdRegistroAsistencia { get; set; }
 

    [Display(Name = "Fecha Registro")]
    public DateOnly FechaRegistro { get; set; }
    [Required(ErrorMessage = "Campo obligatorio")]
    [Display(Name = "Estado")]
    public string EstadoNinoRegistro { get; set; } = null!;

    [Required(ErrorMessage = "Campo obligatorio")]
    [Display(Name = "Niño")]

    public long NinoId { get; set; }
    public virtual Nino Nino { get; set; }


}
