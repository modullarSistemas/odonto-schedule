using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PlanejaOdonto.Api.Migrations
{
    public partial class howarrived : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HowArrived",
                schema: "PlanejaOdontoCore",
                table: "Pacients",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProthesisInstallment",
                schema: "PlanejaOdontoCore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TreatmentId = table.Column<int>(type: "integer", nullable: false),
                    Cost = table.Column<double>(type: "double precision", nullable: false),
                    Due = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Payday = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PaymentMethod = table.Column<byte>(type: "smallint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProthesisInstallment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProthesisInstallment_Treatments_TreatmentId",
                        column: x => x.TreatmentId,
                        principalSchema: "PlanejaOdontoCore",
                        principalTable: "Treatments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProthesisInstallment_TreatmentId",
                schema: "PlanejaOdontoCore",
                table: "ProthesisInstallment",
                column: "TreatmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProthesisInstallment",
                schema: "PlanejaOdontoCore");

            migrationBuilder.DropColumn(
                name: "HowArrived",
                schema: "PlanejaOdontoCore",
                table: "Pacients");
        }
    }
}
