using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_Patient",
                columns: table => new
                {
                    id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(180)", maxLength: 180, nullable: false),
                    Cpf = table.Column<string>(type: "VARCHAR(13)", maxLength: 13, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Adress = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: false),
                    City = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Status = table.Column<bool>(type: "Bit", nullable: false),
                    VaccineId = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Patient", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Vaccine",
                columns: table => new
                {
                    id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Manufacture = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Lot = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    DateValidity = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false),
                    NumberOfDoses = table.Column<int>(type: "int", nullable: false),
                    IntervalBetweenDoses = table.Column<long>(type: "BIGINT", nullable: false),
                    PatienteId = table.Column<long>(type: "BIGINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Vaccine", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PatientVaccine",
                columns: table => new
                {
                    Patientsid = table.Column<long>(type: "BIGINT", nullable: false),
                    Vaccineid = table.Column<long>(type: "BIGINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientVaccine", x => new { x.Patientsid, x.Vaccineid });
                    table.ForeignKey(
                        name: "FK_PatientVaccine_Tb_Patient_Patientsid",
                        column: x => x.Patientsid,
                        principalTable: "Tb_Patient",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientVaccine_Tb_Vaccine_Vaccineid",
                        column: x => x.Vaccineid,
                        principalTable: "Tb_Vaccine",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientVaccine_Vaccineid",
                table: "PatientVaccine",
                column: "Vaccineid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientVaccine");

            migrationBuilder.DropTable(
                name: "Tb_Patient");

            migrationBuilder.DropTable(
                name: "Tb_Vaccine");
        }
    }
}
