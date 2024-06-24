using System.ComponentModel.DataAnnotations;

namespace icbf_web.Models
{
    public class CreateUsuarioViewModel
    {

        [Required(ErrorMessage = "El campo Nombres es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El nombre debe tener un máximo de 50 caracteres.")]
        [Display(Name = "Nombres")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El campo Dirección es obligatorio.")]
        [MaxLength(255, ErrorMessage = "La dirección debe tener un máximo de 255 caracteres.")]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El campo Cédula es obligatorio.")]
        [RegularExpression(@"^\d{7,10}$", ErrorMessage = "La cédula debe tener entre 7 y 10 dígitos.")]
        [Display(Name = "Cédula")]
        public long Cedula { get; set; }

        [Required(ErrorMessage = "El campo Teléfono es obligatorio.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "El teléfono debe tener 10 dígitos.")]
        [Display(Name = "Teléfono")]
        public long Telefono { get; set; }

        [Required(ErrorMessage = "El campo Estado es obligatorio.")]
        [Display(Name = "Estado")]
        public bool Estado { get; set; }

        [Required(ErrorMessage = "El campo Fecha de Nacimiento es obligatorio.")]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }
        [Display(Name = "Jardín")]
        
        public int? IdJardin { get; set; }
        [Required(ErrorMessage = "El campo Rol es obligatorio.")]
        [Display(Name = "Rol")]
        public string Role { get; set; }

        [Required(ErrorMessage = "El campo Email es obligatorio.")]
        [RegularExpression(@"^\w+[\w.-]*@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "El formato del correo electrónico no es válido.")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")] 

        [StringLength(100, ErrorMessage = "El campo {0} debe tener al menos {2} y como máximo {1} caracteres de longitud.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Required(ErrorMessage = "El campo Confirmar Contraseña es obligatorio.")]
        [Compare("Password", ErrorMessage = "La contraseña y la confirmación de la contraseña no coinciden.")]
        [Display(Name = "Confirmar Contraseña")]
        public string ConfirmPassword { get; set; }

     
    
    }
}
