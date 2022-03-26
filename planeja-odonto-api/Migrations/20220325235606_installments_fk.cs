using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanejaOdonto.Api.Migrations
{
    public partial class installments_fk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Installment_Treatments_TreatmentId",
                table: "Installment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Installment",
                table: "Installment");

            migrationBuilder.RenameTable(
                name: "Installment",
                newName: "Installments");

            migrationBuilder.RenameIndex(
                name: "IX_Installment_TreatmentId",
                table: "Installments",
                newName: "IX_Installments_TreatmentId");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Comission",
                table: "Dentists",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Installments",
                table: "Installments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Installments_Treatments_TreatmentId",
                table: "Installments",
                column: "TreatmentId",
                principalTable: "Treatments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Installments_Treatments_TreatmentId",
                table: "Installments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Installments",
                table: "Installments");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Comission",
                table: "Dentists");

            migrationBuilder.RenameTable(
                name: "Installments",
                newName: "Installment");

            migrationBuilder.RenameIndex(
                name: "IX_Installments_TreatmentId",
                table: "Installment",
                newName: "IX_Installment_TreatmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Installment",
                table: "Installment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Installment_Treatments_TreatmentId",
                table: "Installment",
                column: "TreatmentId",
                principalTable: "Treatments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
