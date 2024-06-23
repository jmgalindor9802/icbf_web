using System.ComponentModel.DataAnnotations;

namespace icbf_web.Models
{
    public class CreateUsuarioViewModel
    {

        [Required(ErrorMessage ="Campo obligatorio")]
        [Display(Name = "Nombres")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Cedula")]
        public long Cedula { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Telefono")]
        
        public long Telefono { get; set; }
        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public bool Estado { get; set; }
        [Display(Name = "Fecha de Nacimiento")]    
        [Required(ErrorMessage = "Campo obligatorio")] 
        public DateTime FechaNacimiento { get; set; }
        [Display(Name = "Jardín")]
        
        public int? IdJardin { get; set; }
        [Display(Name = "Rol")]
        [Required(ErrorMessage = "Campo obligatorio")] 
        public string Role { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")] 

        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")] 

        [StringLength(100, ErrorMessage = "El campo {0} debe tener al menos {2} y como máximo {1} caracteres de longitud.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")] 

        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "El password y la confirmación del password no coinciden.")]
        public string ConfirmPassword { get; set; }

     
    
    }
}
