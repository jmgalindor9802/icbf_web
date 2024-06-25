using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace icbf_web.Models;

public partial class Nino
{
    [Key]
    public long IdNino { get; set; }
    [Required(ErrorMessage = "El campo NUIP es obligatorio.")]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "El NUIP debe tener 10 dígitos.")]
    [Display(Name = "NUIP")]
    public long Nuip { get; set; }

    [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
    [MaxLength(50, ErrorMessage = "El nombre debe tener un máximo de 50 caracteres.")]
    [Display(Name = "Nombre")]
    public string NombreNino { get; set; } = null!;
    [Required(ErrorMessage = "El campo Fecha de Nacimiento es obligatorio.")]
    [Display(Name = "Fecha de Nacimiento")]
    [DataType(DataType.Date, ErrorMessage = "La fecha de nacimiento no tiene un formato válido.")]
    public DateOnly FechaNacimientoNino { get; set; }
    [Required(ErrorMessage = "El campo Tipo de Sangre es obligatorio.")]
    [Display(Name = "Tipo de Sangre")]
    public string TipoSangreNino { get; set; } = null!;
    [Required(ErrorMessage = "El campo Lugar de Nacimiento es obligatorio.")]
    [MaxLength(255, ErrorMessage = "El lugar de nacimiento debe tener un máximo de 255 caracteres.")]
    [Display(Name = "Lugar de Nacimiento")]
    public string CiudadNacimientoNino { get; set; } = null!;
    [Required(ErrorMessage = "El campo Acudiente es obligatorio.")]
    [Display(Name = "Acudiente")]
    public string UsuarioId { get; set; } = null!;
    [Required(ErrorMessage = "El campo Teléfono es obligatorio.")]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "El teléfono debe tener 10 dígitos.")]
    [Display(Name = "Teléfono")]
    public long TelefonoNino { get; set; }
    [Required(ErrorMessage = "El campo Dirección de Residencia es obligatorio.")]
    [MaxLength(255, ErrorMessage = "La dirección debe tener un máximo de 255 caracteres.")]
    [Display(Name = "Dirección de Residencia")]
    public string DireccionNino { get; set; } = null!;
    [Required(ErrorMessage = "El campo EPS es obligatorio.")]
    [MaxLength(100, ErrorMessage = "La EPS debe tener un máximo de 100 caracteres.")]
    [Display(Name = "EPS")]
    public string EpsNino { get; set; } = null!;

    [Required(ErrorMessage = "El campo Jardín es obligatorio.")]
    [Display(Name = "Jardín")]
    public int JardinId { get; set; }
    public virtual Jardin Jardin{ get; set; }



    public virtual ICollection<RegistroAsistencia> RegistrosAsistencia { get; set; } = new List<RegistroAsistencia>();

    public virtual ICollection<RegistroAvanceAcademico> RegistrosAvanceAcademicos { get; set; } = new List<RegistroAvanceAcademico>();
}
