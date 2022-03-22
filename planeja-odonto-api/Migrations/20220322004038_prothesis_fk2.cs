using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanejaOdonto.Api.Migrations
{
    public partial class prothesis_fk2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Procedures_Prothesis_ProthesisId",
                table: "Procedures");

            migrationBuilder.AlterColumn<int>(
                name: "ProthesisId",
                table: "Procedures",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Procedures",
                table: "Procedures",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Procedures_Prothesis_ProthesisId",
                table: "Procedures",
                column: "ProthesisId",
                principalTable: "Prothesis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Procedures_Prothesis_ProthesisId",
                table: "Procedures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Procedures",
                table: "Procedures");

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
    }
}
