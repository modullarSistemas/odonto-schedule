using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanejaOdonto.Api.Migrations
{
    public partial class DentistRelationUserTable3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedulings_ProcedureTypes_ProcedureTypeId",
                table: "Schedulings");

            migrationBuilder.DropIndex(
                name: "IX_Schedulings_ProcedureTypeId",
                table: "Schedulings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Schedulings_ProcedureTypeId",
                table: "Schedulings",
                column: "ProcedureTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedulings_ProcedureTypes_ProcedureTypeId",
                table: "Schedulings",
                column: "ProcedureTypeId",
                principalTable: "ProcedureTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
