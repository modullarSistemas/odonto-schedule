using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PlanejaOdonto.Api.Migrations
{
    public partial class protese : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NeedProthesis",
                table: "ProcedureTypes");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Treatments",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Prothesis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cost = table.Column<double>(type: "double precision", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prothesis", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prothesis");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Treatments");

            migrationBuilder.AddColumn<bool>(
                name: "NeedProthesis",
                table: "ProcedureTypes",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
