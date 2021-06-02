using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VaccineManagement.ViewModels
{
    public class UpdatePatientViewModel
    {
        [Required(ErrorMessage = "the id cannot be empty")]
        [Range(1, long.MaxValue, ErrorMessage = "The id cannot be less than 1")]
        public int id { get; set; }
        [Required(ErrorMessage = "The name is required")]
        [MinLength(3, ErrorMessage = "The email must be at least 2 characters long")]
        [MaxLength(80, ErrorMessage = "The email must be up to 80 characters long")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The email is required")]
        [MinLength(10, ErrorMessage = "The email must be at least 10 characters long")]
        [MaxLength(180, ErrorMessage = "The email must be up to 80 characters long")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Invalid email!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "CPF is required!")]
        [MinLength(11, ErrorMessage = "O cpf deve ter no minimo 11 caracteres")]
        [MaxLength(11, ErrorMessage = "O cpf deve ter no maximo 11 caracteres")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Date od birth is required!")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Status is required!")]
        public bool StatusCadastro { get; set; }
    }
}
