using Domain.Entities;
using Infra.Mappings;
using Infra.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Context
{
    public class DataContext : DbContext
    {
        public DataContext() { }

        public virtual DbSet<Patient> patients { get; set; }
        public virtual DbSet<Vaccine> vaccines { get; set; }
        public virtual DbSet<VaccineRegistration> VaccineRegistrations { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=ARCANJO-PC\SQLEXPRESS;Initial Catalog=DB_Vaccine;Persist Security Info=True;User ID=ArcanjoAdmin;Password=69451916");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PatientMap());
            builder.ApplyConfiguration(new VaccineMap());
            builder.ApplyConfiguration(new VaccineRegistrationMAP());
        }

    }
}
