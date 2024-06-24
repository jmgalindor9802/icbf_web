using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace icbf_web.Models;

public partial class Jardin
{
    [Key]
    public int IdJardin { get; set; }
    [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
    [MaxLength(100, ErrorMessage = "El nombre del jardín debe tener un máximo de 100 caracteres.")]
    [Display(Name = "Nombre")]
    public string NombreJardin { get; set; } = null!;
    [Required(ErrorMessage = "El campo Dirección es obligatorio.")]
    [MaxLength(255, ErrorMessage = "La dirección debe tener un máximo de 255 caracteres.")]
    [Display(Name = "Dirección")]
    public string DireccionJardin { get; set; } = null!;
    [Required(ErrorMessage = "El campo Estado es obligatorio.")]
    [Display(Name = "Estado")]
    public string EstadoJardin { get; set; } = null!;



    public virtual ICollection<Nino> Ninos { get; set; } = new List<Nino>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
