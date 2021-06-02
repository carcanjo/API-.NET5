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
    public class VaccineMap : IEntityTypeConfiguration<Vaccine>
    {
        public void Configure(EntityTypeBuilder<Vaccine> builder)
        {
            builder.ToTable("Tb_Vaccine")
                .HasKey(x => x.id);

            builder.Property(x => x.id)
                .UseIdentityColumn()
                .HasColumnType("BIGINT");
            
            builder.Property(x => x.Manufacture)
                .IsRequired()
                .HasColumnName("Manufacture")
                .HasMaxLength(100)
                .HasColumnType("VARCHAR(100)");
               
            builder.Property(x => x.Lot)
                .IsRequired()
                .HasColumnName("Lot")
                .HasMaxLength(100)
                .HasColumnType("VARCHAR(100)");

            builder.Property(X => X.DateValidity)
                .IsRequired()
                .HasColumnName("DateValidity")
                .HasColumnType<DateTime>("SMALLDATETIME");

            builder.Property(x => x.IntervalBetweenDoses)
                .IsRequired()
                .HasColumnName("IntervalBetweenDoses")
                .HasColumnType("BIGINT");

            builder.Property(x => x.PatienteId)
                .IsRequired()
                .HasColumnName("PatienteId")
                .HasColumnType("BIGINT");

        }
    }
}