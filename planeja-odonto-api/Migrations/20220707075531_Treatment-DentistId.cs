using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanejaOdonto.Api.Migrations
{
    public partial class TreatmentDentistId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Procedures_Dentists_DentistId",
                table: "Procedures");

            migrationBuilder.DropIndex(
                name: "IX_Procedures_DentistId",
                table: "Procedures");

            migrationBuilder.DropColumn(
                name: "DentistId",
                table: "Procedures");

            migrationBuilder.AddColumn<int>(
                name: "DentistId",
                table: "Treatments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_DentistId",
                table: "Treatments",
                column: "DentistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Treatments_Dentists_DentistId",
                table: "Treatments",
                column: "DentistId",
                principalTable: "Dentists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Treatments_Dentists_DentistId",
                table: "Treatments");

            migrationBuilder.DropIndex(
                name: "IX_Treatments_DentistId",
                table: "Treatments");

            migrationBuilder.DropColumn(
                name: "DentistId",
                table: "Treatments");

            migrationBuilder.AddColumn<int>(
                name: "DentistId",
                table: "Procedures",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_DentistId",
                table: "Procedures",
                column: "DentistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Procedures_Dentists_DentistId",
                table: "Procedures",
                column: "DentistId",
                principalTable: "Dentists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
