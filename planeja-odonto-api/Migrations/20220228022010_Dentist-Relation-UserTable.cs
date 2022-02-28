using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanejaOdonto.Api.Migrations
{
    public partial class DentistRelationUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProcedureTypeId",
                table: "Schedulings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ScheduledBy",
                table: "Schedulings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "Schedulings",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Dentists",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.DropColumn(
                name: "ProcedureTypeId",
                table: "Schedulings");

            migrationBuilder.DropColumn(
                name: "ScheduledBy",
                table: "Schedulings");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Schedulings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Dentists");
        }
    }
}
