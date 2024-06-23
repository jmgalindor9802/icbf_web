﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace icbf_web.Models;

public partial class Jardin
{
    [Key]
    public int IdJardin { get; set; }
    [Required(ErrorMessage = "Campo obligatorio")]
    [MaxLength(100, ErrorMessage = "El nombre del jardin como maximo debetener 100 caracteres")]
    [MinLength(8, ErrorMessage = "El nombre del jardin como minimo debe tener 8 caracteres")]
    [Display(Name = "Nombre")]
    public string NombreJardin { get; set; } = null!;
    [Required(ErrorMessage = "Campo obligatorio")]
    [MaxLength(200, ErrorMessage = "La direccion del jardin como maximo debetener 200 caracteres")]
    [MinLength(8, ErrorMessage = "La direccion del jardin como minimo debe tener 8 caracteres")]
    [Display(Name = "Dirección")]
    public string DireccionJardin { get; set; } = null!;
    [Required(ErrorMessage = "Campo obligatorio")]
    [Display(Name = "Estado")]
    public string EstadoJardin { get; set; } = null!;



    public virtual ICollection<Nino> Ninos { get; set; } = new List<Nino>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
