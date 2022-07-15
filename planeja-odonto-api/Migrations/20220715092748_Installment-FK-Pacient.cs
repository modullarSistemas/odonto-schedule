using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanejaOdonto.Api.Migrations
{
    public partial class InstallmentFKPacient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Installments_Treatments_TreatmentId",
                schema: "PlanejaOdontoCore",
                table: "Installments");

            migrationBuilder.DropIndex(
                name: "IX_Installments_TreatmentId",
                schema: "PlanejaOdontoCore",
                table: "Installments");

            migrationBuilder.DropColumn(
                name: "TreatmentId",
                schema: "PlanejaOdontoCore",
                table: "Installments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TreatmentId",
                schema: "PlanejaOdontoCore",
                table: "Installments",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Installments_TreatmentId",
                schema: "PlanejaOdontoCore",
                table: "Installments",
                column: "TreatmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Installments_Treatments_TreatmentId",
                schema: "PlanejaOdontoCore",
                table: "Installments",
                column: "TreatmentId",
                principalSchema: "PlanejaOdontoCore",
                principalTable: "Treatments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
