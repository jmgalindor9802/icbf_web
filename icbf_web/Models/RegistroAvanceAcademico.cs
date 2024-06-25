using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace icbf_web.Models;

public partial class RegistroAvanceAcademico
{
    [Key]
    public int IdAvance { get; set; }
    [Required(ErrorMessage = "Campo obligatorio")]
    [Display(Name = "Niño")]
    public long NinoId { get; set; }
    public virtual Nino Nino { get; set; }
    [Required(ErrorMessage = "Campo obligatorio")]
    [Display(Name = "Año escolar")]
    public int AnioEscolarAvance { get; set; }
    [Required(ErrorMessage = "Campo obligatorio")]
    [Display(Name = "Nivel de avance")]
    public string NivelAvance { get; set; } = null!;
    [Required(ErrorMessage = "Campo obligatorio")]
    [Display(Name = "Nota")]
    public string NotaAvance { get; set; } = null!;
    [Required(ErrorMessage = "Campo obligatorio")]
    [Display(Name = "Descripción")]
    public string DescripcionAvance { get; set; } = null!;
    [Required(ErrorMessage = "Campo obligatorio")]
    [Display(Name = "Fecha de entrega")]
    public DateOnly FechaEntregaAvance { get; set; }
}
