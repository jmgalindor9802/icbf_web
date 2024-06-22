using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace icbf_web.Models;

public partial class MadreComunitaria
{
    [Key]
    public int IdMadreComunitaria { get; set; }
    [Required(ErrorMessage = "Campo obligatorio")]

    [DataType(DataType.Date)]
    public DateOnly FechaNacimientoMadre { get; set; }
    [Required(ErrorMessage = "Campo obligatorio")]
    public int IdJardin { get; set; }
    [Required(ErrorMessage = "Campo obligatorio")]
    public string IdUsuario { get; set; } = null!;

    public virtual Jardin IdJardinNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
