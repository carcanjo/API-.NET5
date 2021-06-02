using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VaccineManagement.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Login não pode ser vazio")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Password não pode ser vazio")]
        public string Password { get; set; }
    }
}
