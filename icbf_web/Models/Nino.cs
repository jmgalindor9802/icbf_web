using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace icbf_web.Models;

public partial class Nino
{
    [Key]
    [Required(ErrorMessage ="Campo obligatorio")]
    [Display(Name = "NUIP")]
    public long IdNino { get; set; }
    [Required(ErrorMessage = "Campo obligatorio")]
    [Display(Name = "Nombre")]
    public string NombreNino { get; set; } = null!;
    [Required(ErrorMessage = "Campo obligatorio")]
    [Display(Name = "Fecha de nacimiento")]
    [DataType(DataType.Date)]
    public DateOnly FechaNacimientoNino { get; set; }
    [Required(ErrorMessage = "Campo obligatorio")]
    [Display(Name = "Tipo de sangre")]
    public string TipoSangreNino { get; set; } = null!;
    [Required(ErrorMessage = "Campo obligatorio")]
    [Display(Name = "Lugar de Nacimiento")]
    public string CiudadNacimientoNino { get; set; } = null!;
    [Required(ErrorMessage = "Campo obligatorio")]
    [Display(Name = "Acudiente")]
  
    public string UsuarioId { get; set; } = null!;
    [Required(ErrorMessage = "Campo obligatorio")]
    [Display(Name = "Teléfono")]
    public long TelefonoNino { get; set; }
    [Required(ErrorMessage = "Campo obligatorio")]
    [Display(Name = "Dirección de residencia")]
    public string DireccionNino { get; set; } = null!;
    [Required(ErrorMessage = "Campo obligatorio")]
    [Display(Name = "EPS")]
    public string EpsNino { get; set; } = null!;

    [Required(ErrorMessage = "Campo obligatorio")]
    [Display(Name = "Jardin")]
    public int JardinId { get; set; } 



    public virtual ICollection<RegistroAsistencia> RegistrosAsistencia { get; set; } = new List<RegistroAsistencia>();

    public virtual ICollection<RegistroAvanceAcademico> RegistrosAvanceAcademicos { get; set; } = new List<RegistroAvanceAcademico>();
}
