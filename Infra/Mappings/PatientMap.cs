using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Migrations
{
    public class PatientMap : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Tb_Patient");
            builder.HasKey(x => x.id);
            builder.Property(x => x.id)
                .UseIdentityColumn()
                .HasColumnType("BIGINT");

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnName("Name")
                .HasColumnType("VARCHAR(80)");
            
            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(180)
                .HasColumnName("Email")
                .HasColumnType("VARCHAR(180)");

            builder.Property(X => X.Cpf)
                .IsRequired()
                .HasMaxLength(13)
                .HasColumnName("Cpf")
                .HasColumnType("VARCHAR(30)");

            builder.Property(x => x.DateOfBirth)
                .IsRequired()
                .HasColumnName("DateOfBirth")
                .HasColumnType("DateTime");

            builder.Property(x => x.Address)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("Adress")
                .HasColumnType("VARCHAR(300)");

            builder.Property(x => x.City)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("City")
                .HasColumnType("VARCHAR(100)");

            builder.Property(x => x.RegistrationDate)
                .IsRequired()
                .HasColumnName("RegistrationDate")
                .HasColumnType("DateTime");

            builder.Property(x => x.Status)
                .IsRequired()
                .HasColumnName("Status")
                .HasColumnType("Bit");

            builder.Property(x => x.VaccineId)
                .IsRequired()
                .HasColumnName("VaccineId")
                .HasColumnType("INT");
        }
    }
}
