﻿// <auto-generated />
using System;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infra.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210527001954_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.Patient", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIGINT")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("VARCHAR(150)")
                        .HasColumnName("Adress");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("City");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("VARCHAR(13)")
                        .HasColumnName("Cpf");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("DateTime")
                        .HasColumnName("DateOfBirth");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(180)
                        .HasColumnType("VARCHAR(180)")
                        .HasColumnName("Email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR(80)")
                        .HasColumnName("Name");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("DateTime")
                        .HasColumnName("RegistrationDate");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("Bit")
                        .HasColumnName("Status");

                    b.Property<int>("VaccineId")
                        .HasColumnType("INT")
                        .HasColumnName("VaccineId");

                    b.HasKey("id");

                    b.ToTable("Tb_Patient");
                });

            modelBuilder.Entity("Domain.Entities.Vaccine", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIGINT")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateValidity")
                        .HasColumnType("SMALLDATETIME")
                        .HasColumnName("DateValidity");

                    b.Property<long>("IntervalBetweenDoses")
                        .HasColumnType("BIGINT")
                        .HasColumnName("IntervalBetweenDoses");

                    b.Property<string>("Lot")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("Lot");

                    b.Property<string>("Manufacture")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("Manufacture");

                    b.Property<int>("NumberOfDoses")
                        .HasColumnType("int");

                    b.Property<long>("PatienteId")
                        .HasColumnType("BIGINT")
                        .HasColumnName("PatienteId");

                    b.HasKey("id");

                    b.ToTable("Tb_Vaccine");
                });

            modelBuilder.Entity("PatientVaccine", b =>
                {
                    b.Property<long>("Patientsid")
                        .HasColumnType("BIGINT");

                    b.Property<long>("Vaccineid")
                        .HasColumnType("BIGINT");

                    b.HasKey("Patientsid", "Vaccineid");

                    b.HasIndex("Vaccineid");

                    b.ToTable("PatientVaccine");
                });

            modelBuilder.Entity("PatientVaccine", b =>
                {
                    b.HasOne("Domain.Entities.Patient", null)
                        .WithMany()
                        .HasForeignKey("Patientsid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Vaccine", null)
                        .WithMany()
                        .HasForeignKey("Vaccineid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
