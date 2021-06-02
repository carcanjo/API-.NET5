using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Mappings
{
    public class VaccineRegistrationMAP : IEntityTypeConfiguration<VaccineRegistration>
    {
        public void Configure(EntityTypeBuilder<VaccineRegistration> builder)
        {
            builder.ToTable("Tb_RegistrationVaccine")
                .HasKey(x => x.id);

            builder.Property(x => x.VaccinationDate)
                .IsRequired()
                .HasColumnName("VaccinationDate")
                .HasColumnType<DateTime>("SMALLDATETIME");

            builder.Property(x => x.FirtDose)
                .IsRequired()
                .HasColumnName("FirtDose")
                .HasColumnType<DateTime>("SMALLDATETIME");

            builder.Property(x => x.SecondDose)
                .HasColumnName("SecondDose")
                .HasColumnType<DateTime?>("SMALLDATETIME");

            builder.Property(x => x.PatientId)
                .IsRequired()
                .HasColumnName("PatientId")
                .HasColumnType("BIGINT");

            
            builder.Property(x => x.VaccineId)
                .IsRequired()
                .HasColumnName("VaccineId")
                .HasColumnType("BIGINT");

        }
    }
}
