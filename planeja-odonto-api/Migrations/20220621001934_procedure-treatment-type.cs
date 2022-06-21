using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanejaOdonto.Api.Migrations
{
    public partial class proceduretreatmenttype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "TreatmentType",
                table: "ProcedureTypes",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TreatmentType",
                table: "ProcedureTypes");
        }
    }
}
