using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class PatientDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool StatusCadastro { get; set; }
        public Vaccine Vaccine { get; set; }



        public PatientDTO() { }

        public PatientDTO(long id, string name, string email, string cpf, DateTime dataNascimento, DateTime dataCadastro, bool statusCadastro)
        {
            Id = id;
            Name = name;
            Email = email;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            DataCadastro = dataCadastro;
            StatusCadastro = statusCadastro;
        }
    }
}
