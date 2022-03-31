using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanejaOdonto.Api.Migrations
{
    public partial class NullableProcedureTypeScheduling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedulings_ProcedureTypes_ProcedureTypeId",
                table: "Schedulings");

            migrationBuilder.AlterColumn<int>(
                name: "ProcedureTypeId",
                table: "Schedulings",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedulings_ProcedureTypes_ProcedureTypeId",
                table: "Schedulings",
                column: "ProcedureTypeId",
                principalTable: "ProcedureTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedulings_ProcedureTypes_ProcedureTypeId",
                table: "Schedulings");

            migrationBuilder.AlterColumn<int>(
                name: "ProcedureTypeId",
                table: "Schedulings",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedulings_ProcedureTypes_ProcedureTypeId",
                table: "Schedulings",
                column: "ProcedureTypeId",
                principalTable: "ProcedureTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
