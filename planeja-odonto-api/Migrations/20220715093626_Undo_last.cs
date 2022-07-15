using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanejaOdonto.Api.Migrations
{
    public partial class Undo_last : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Installments_Pacients_PacientId",
                schema: "PlanejaOdontoCore",
                table: "Installments");

            migrationBuilder.RenameColumn(
                name: "PacientId",
                schema: "PlanejaOdontoCore",
                table: "Installments",
                newName: "TreatmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Installments_PacientId",
                schema: "PlanejaOdontoCore",
                table: "Installments",
                newName: "IX_Installments_TreatmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Installments_Treatments_TreatmentId",
                schema: "PlanejaOdontoCore",
                table: "Installments",
                column: "TreatmentId",
                principalSchema: "PlanejaOdontoCore",
                principalTable: "Treatments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Installments_Treatments_TreatmentId",
                schema: "PlanejaOdontoCore",
                table: "Installments");

            migrationBuilder.RenameColumn(
                name: "TreatmentId",
                schema: "PlanejaOdontoCore",
                table: "Installments",
                newName: "PacientId");

            migrationBuilder.RenameIndex(
                name: "IX_Installments_TreatmentId",
                schema: "PlanejaOdontoCore",
                table: "Installments",
                newName: "IX_Installments_PacientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Installments_Pacients_PacientId",
                schema: "PlanejaOdontoCore",
                table: "Installments",
                column: "PacientId",
                principalSchema: "PlanejaOdontoCore",
                principalTable: "Pacients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
