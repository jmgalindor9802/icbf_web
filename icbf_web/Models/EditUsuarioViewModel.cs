using System.ComponentModel.DataAnnotations;

namespace icbf_web.Models
{
    public class EditUsuarioViewModel
    {
        [Key]
        public string Id { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Nombres")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }


        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Telefono")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "El número de teléfono debe tener exactamente 10 dígitos.")]

        public long Telefono { get; set; }
        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public bool Estado { get; set; }
        
        [Display(Name = "Jardín")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public int? IdJardin { get; set; }
        [Display(Name = "Rol")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Role { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]

        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

      

    }
}
