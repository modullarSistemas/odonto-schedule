using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanejaOdonto.Api.Migrations
{
    public partial class prothesis_fk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Procedures",
                table: "Procedures");

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
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Procedures_Prothesis_ProthesisId",
                table: "Procedures");

            migrationBuilder.DropIndex(
                name: "IX_Procedures_ProthesisId",
                table: "Procedures");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Procedures",
                table: "Procedures",
                column: "Id");
        }
    }
}
