using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanejaOdonto.Api.Migrations
{
    public partial class treatmentupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Procedures_Prothesis_ProthesisId",
                table: "Procedures");

            migrationBuilder.AddColumn<string>(
                name: "Anamnesis",
                table: "Treatments",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ProthesisCost",
                table: "Treatments",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "ProthesisId",
                table: "Procedures",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Procedures_Prothesis_ProthesisId",
                table: "Procedures",
                column: "ProthesisId",
                principalTable: "Prothesis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Procedures_Prothesis_ProthesisId",
                table: "Procedures");

            migrationBuilder.DropColumn(
                name: "Anamnesis",
                table: "Treatments");

            migrationBuilder.DropColumn(
                name: "ProthesisCost",
                table: "Treatments");

            migrationBuilder.AlterColumn<int>(
                name: "ProthesisId",
                table: "Procedures",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Procedures_Prothesis_ProthesisId",
                table: "Procedures",
                column: "ProthesisId",
                principalTable: "Prothesis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
