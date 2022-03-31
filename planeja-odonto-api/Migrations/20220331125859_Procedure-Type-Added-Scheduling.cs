using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanejaOdonto.Api.Migrations
{
    public partial class ProcedureTypeAddedScheduling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedulings_Procedures_MyPropertyId",
                table: "Schedulings");

            migrationBuilder.DropIndex(
                name: "IX_Schedulings_MyPropertyId",
                table: "Schedulings");

            migrationBuilder.DropColumn(
                name: "MyPropertyId",
                table: "Schedulings");

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
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedulings_ProcedureTypes_ProcedureTypeId",
                table: "Schedulings");

            migrationBuilder.DropIndex(
                name: "IX_Schedulings_ProcedureTypeId",
                table: "Schedulings");

            migrationBuilder.AddColumn<int>(
                name: "MyPropertyId",
                table: "Schedulings",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedulings_MyPropertyId",
                table: "Schedulings",
                column: "MyPropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedulings_Procedures_MyPropertyId",
                table: "Schedulings",
                column: "MyPropertyId",
                principalTable: "Procedures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
