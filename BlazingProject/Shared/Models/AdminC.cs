using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace BlazingProject.Shared.Models
{
    public class AdminC
    {
        public int ID { get; set; } //ID
        [Required]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "verifica tu ID")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Solo se aceptan números")]
        public string Matricula { get; set; } //Matricula

        [Required]
        [RegularExpression(@"[a-z0-9._%+-]+@utpuebla.edu.mx", ErrorMessage = "Solo se aceptan correos institucionales")]

        public string Email { get; set; }//correo
        [Required(ErrorMessage = "Campo obligatorio")]
        public string LastName { get; set; } //Apellido paterno
        [Required(ErrorMessage = "Campo obligatorio")]
        public string LastNameMother { get; set; } //Apellido materno
        [Required(ErrorMessage = "Campo obligatorio")]
        public string FirstName { get; set; } //Nombre

    }
}
