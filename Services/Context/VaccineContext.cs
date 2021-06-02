using Domain.Entities;
using Infra.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Context
{
    class VaccineContext : DbContext
    {
        public VaccineContext() { }
        public VaccineContext(DbContextOptions<VaccineContext> options) : base(options) { }

        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Vaccine> Vaccines { get; set; }
        public virtual DbSet<VaccineRegistration> VaccineRegistrations { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=ARCANJO-PC\SQLEXPRESS;Initial Catalog=DB_Vaccine;Persist Security Info=True;User ID=ArcanjoAdmin;Password=69451916");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PatientMap());
        }
    }
}
