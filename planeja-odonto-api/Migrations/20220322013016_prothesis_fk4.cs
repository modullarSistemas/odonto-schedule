using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanejaOdonto.Api.Migrations
{
    public partial class prothesis_fk4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Procedures_Prothesis_ProthesisId",
                table: "Procedures");

            migrationBuilder.DropIndex(
                name: "IX_Procedures_ProthesisId",
                table: "Procedures");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Procedures_ProthesisId",
                table: "Procedures",
                column: "ProthesisId");

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
