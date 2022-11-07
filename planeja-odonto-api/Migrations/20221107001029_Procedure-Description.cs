using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanejaOdonto.Api.Migrations
{
    public partial class ProcedureDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                schema: "PlanejaOdontoCore",
                table: "Treatments",
                type: "integer",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(byte),
                oldType: "smallint",
                oldDefaultValue: (byte)1);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "PlanejaOdontoCore",
                table: "Procedures",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                schema: "PlanejaOdontoCore",
                table: "Procedures");

            migrationBuilder.AlterColumn<byte>(
                name: "Status",
                schema: "PlanejaOdontoCore",
                table: "Treatments",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)1,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 1);
        }
    }
}
