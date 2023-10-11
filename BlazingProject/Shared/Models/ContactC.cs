using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using static System.Net.WebRequestMethods;
using Newtonsoft.Json.Serialization;

namespace BlazingProject.Shared.Models
{
    public class ContactC
    {
        public int ID { get; set; } //ID
        [Required(ErrorMessage = "Campo ID obligatorio")]
        [StringLength(4,MinimumLength =4,ErrorMessage ="verifica tu ID")]
        [RegularExpression("^[0-9]+$",ErrorMessage ="Solo se aceptan números")]
        public string Matricula { get; set; } //Matricula

        [Required(ErrorMessage = "Campo correo obligatorio")]
        [RegularExpression(@"[a-z0-9._%+-]+@utpuebla.edu.mx",ErrorMessage ="Solo se aceptan correos institucionales")]

        public string Email { get; set; }//correo
        [Required(ErrorMessage = "Campo telefono obligatorio")]
        [StringLength(10, MinimumLength = 10,ErrorMessage = "Verifica tu número")]
        [RegularExpression("^[0-9]+$",ErrorMessage = "Solo se aceptan correos institucionales")]
        public string Phone { get; set; } //telefono
        [Required(ErrorMessage = "Campo Apellido paterno obligatorio")]
        public string LastName { get; set; } //Apellido paterno
        [Required(ErrorMessage = "Campo Apellido materno obligatorio")]
        public string LastNameMother { get; set; } //Apellido materno
        [Required(ErrorMessage = "Campo Nombre obligatorio")]
        public string FirstName { get; set; } //Nombre
        [Required(ErrorMessage = "Campo Asunto obligatorio")]
        public string Subject { get; set; } //Asunto		
        [Required(ErrorMessage = "Campo Mensaje obligatorio")]
        public string Message { get; set; } //mensaje
	}
}
