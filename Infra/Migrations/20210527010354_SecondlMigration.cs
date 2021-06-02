using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class SecondlMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_RegistrationVaccine",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VaccinationDate = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false),
                    FirtDose = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false),
                    SecondDose = table.Column<DateTime>(type: "SMALLDATETIME", nullable: true),
                    PatientId = table.Column<long>(type: "BIGINT", nullable: false),
                    VaccineId = table.Column<long>(type: "BIGINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_RegistrationVaccine", x => x.id);
                    table.ForeignKey(
                        name: "FK_Tb_RegistrationVaccine_Tb_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Tb_Patient",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tb_RegistrationVaccine_Tb_Vaccine_VaccineId",
                        column: x => x.VaccineId,
                        principalTable: "Tb_Vaccine",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_RegistrationVaccine_PatientId",
                table: "Tb_RegistrationVaccine",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_RegistrationVaccine_VaccineId",
                table: "Tb_RegistrationVaccine",
                column: "VaccineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_RegistrationVaccine");
        }
    }
}
