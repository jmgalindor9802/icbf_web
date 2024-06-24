using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace icbf_web.Models;

public partial class Nino
{
    [Key]
    [Required(ErrorMessage = "El campo NUIP es obligatorio.")]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "El NUIP debe tener 10 dígitos.")]
    [Display(Name = "NUIP")]
    public long IdNino { get; set; }
    [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
    [MaxLength(50, ErrorMessage = "El nombre debe tener un máximo de 50 caracteres.")]
    [Display(Name = "Nombre")]
    public string NombreNino { get; set; } = null!;
    [Required(ErrorMessage = "El campo Fecha de Nacimiento es obligatorio.")]
    [Display(Name = "Fecha de Nacimiento")]
    [DataType(DataType.Date, ErrorMessage = "La fecha de nacimiento no tiene un formato válido.")]
    public DateOnly FechaNacimientoNino { get; set; }
    [Required(ErrorMessage = "Campo obligatorio")]
    [Display(Name = "Tipo de sangre")]
    public string TipoSangreNino { get; set; } = null!;
    [Required(ErrorMessage = "Campo obligatorio")]
    [MaxLength(255, ErrorMessage = "b")]
    [Display(Name = "Lugar de Nacimiento")]
    public string CiudadNacimientoNino { get; set; } = null!;
    [Required(ErrorMessage = "Campo obligatorio")]
    [Display(Name = "Acudiente")]
    public string UsuarioId { get; set; } = null!;
    [Required(ErrorMessage = "Campo obligatorio")]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "El teléfono debe tener 10 dígitos.")]
    [Display(Name = "Teléfono")]
    public long TelefonoNino { get; set; }
    [Required(ErrorMessage = "Campo obligatorio")]
    [MaxLength(255, ErrorMessage = "b")]
    [Display(Name = "Dirección de residencia")]
    public string DireccionNino { get; set; } = null!;
    [Required(ErrorMessage = "Campo obligatorio")]
    [MaxLength(100, ErrorMessage = "p")]
    [Display(Name = "EPS")]
    public string EpsNino { get; set; } = null!;

    [Required(ErrorMessage = "Campo obligatorio")]
    [Display(Name = "Jardin")]
    public int JardinId { get; set; } 



    public virtual ICollection<RegistroAsistencia> RegistrosAsistencia { get; set; } = new List<RegistroAsistencia>();

    public virtual ICollection<RegistroAvanceAcademico> RegistrosAvanceAcademicos { get; set; } = new List<RegistroAvanceAcademico>();
}
