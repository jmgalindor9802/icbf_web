using System.ComponentModel.DataAnnotations;

namespace icbf_web.Models
{
    public class EditUsuarioViewModel
    {
        [Key]
        public string Id { get; set; }
        [Display(Name = "Nombres")]
        public string Nombres { get; set; }
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }
        [Display(Name = "Telefono")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "El número de teléfono debe tener exactamente 10 dígitos.")]

        public long Telefono { get; set; }
        [Display(Name = "Estado")]
        public bool Estado { get; set; }
        [Display(Name = "Jardín")]
        public int? IdJardin { get; set; }
        [Display(Name = "Rol")]
        
        public string Role { get; set; }
        [RegularExpression(@"^\w+[\w.-]*@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "El formato del correo electrónico no es válido.")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

      

    }
}
