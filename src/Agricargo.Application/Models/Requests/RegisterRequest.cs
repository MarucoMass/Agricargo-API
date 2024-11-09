using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricargo.Application.Models.Requests
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "Parametro Nombre necesario")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Parametro Email necesario")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Parametro Contraseña necesario")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Parametro Role necesario")]
        public string Role { get; set; }
        public string? CompanyName { get; set; }
    }
}
