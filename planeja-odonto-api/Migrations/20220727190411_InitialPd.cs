using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PlanejaOdonto.Api.Migrations
{
    public partial class InitialPd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "PlanejaOdontoCore");

            migrationBuilder.CreateTable(
                name: "Franchisees",
                schema: "PlanejaOdontoCore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Franchisees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcedureTypes",
                schema: "PlanejaOdontoCore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Cost = table.Column<double>(type: "double precision", nullable: false),
                    TreatmentType = table.Column<byte>(type: "smallint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcedureTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prothesis",
                schema: "PlanejaOdontoCore",
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

            migrationBuilder.CreateTable(
                name: "Franchises",
                schema: "PlanejaOdontoCore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FranchiseeId = table.Column<int>(type: "integer", nullable: false),
                    City = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<string>(type: "text", nullable: true),
                    District = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Franchises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Franchises_Franchisees_FranchiseeId",
                        column: x => x.FranchiseeId,
                        principalSchema: "PlanejaOdontoCore",
                        principalTable: "Franchisees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dentists",
                schema: "PlanejaOdontoCore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Comission = table.Column<double>(type: "double precision", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    FranchiseId = table.Column<int>(type: "integer", nullable: false),
                    Category = table.Column<byte>(type: "smallint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dentists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dentists_Franchises_FranchiseId",
                        column: x => x.FranchiseId,
                        principalSchema: "PlanejaOdontoCore",
                        principalTable: "Franchises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationSchedulings",
                schema: "PlanejaOdontoCore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ScheduledBy = table.Column<int>(type: "integer", nullable: false),
                    FranchiseId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Status = table.Column<byte>(type: "smallint", nullable: false, defaultValue: (byte)1),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationSchedulings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluationSchedulings_Franchises_FranchiseId",
                        column: x => x.FranchiseId,
                        principalSchema: "PlanejaOdontoCore",
                        principalTable: "Franchises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pacients",
                schema: "PlanejaOdontoCore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FranchiseId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CPF = table.Column<string>(type: "text", nullable: true),
                    Rg = table.Column<string>(type: "text", nullable: true),
                    Gender = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Profession = table.Column<string>(type: "text", nullable: true),
                    CivilState = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacients_Franchises_FranchiseId",
                        column: x => x.FranchiseId,
                        principalSchema: "PlanejaOdontoCore",
                        principalTable: "Franchises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "PlanejaOdontoCore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FranchiseId = table.Column<int>(type: "integer", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Franchises_FranchiseId",
                        column: x => x.FranchiseId,
                        principalSchema: "PlanejaOdontoCore",
                        principalTable: "Franchises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adresses",
                schema: "PlanejaOdontoCore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PacientId = table.Column<int>(type: "integer", nullable: false),
                    City = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<string>(type: "text", nullable: true),
                    ZipCode = table.Column<string>(type: "text", nullable: true),
                    District = table.Column<string>(type: "text", nullable: true),
                    Street = table.Column<string>(type: "text", nullable: true),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    Complement = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adresses_Pacients_PacientId",
                        column: x => x.PacientId,
                        principalSchema: "PlanejaOdontoCore",
                        principalTable: "Pacients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dependants",
                schema: "PlanejaOdontoCore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PacientId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Gender = table.Column<string>(type: "text", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dependants_Pacients_PacientId",
                        column: x => x.PacientId,
                        principalSchema: "PlanejaOdontoCore",
                        principalTable: "Pacients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProcedureSchedulings",
                schema: "PlanejaOdontoCore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ProcedureTypeId = table.Column<int>(type: "integer", nullable: false),
                    PacientId = table.Column<int>(type: "integer", nullable: false),
                    DentistId = table.Column<int>(type: "integer", nullable: false),
                    ScheduledBy = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<byte>(type: "smallint", nullable: false, defaultValue: (byte)1),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcedureSchedulings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcedureSchedulings_Dentists_DentistId",
                        column: x => x.DentistId,
                        principalSchema: "PlanejaOdontoCore",
                        principalTable: "Dentists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcedureSchedulings_Pacients_PacientId",
                        column: x => x.PacientId,
                        principalSchema: "PlanejaOdontoCore",
                        principalTable: "Pacients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcedureSchedulings_ProcedureTypes_ProcedureTypeId",
                        column: x => x.ProcedureTypeId,
                        principalSchema: "PlanejaOdontoCore",
                        principalTable: "ProcedureTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Treatments",
                schema: "PlanejaOdontoCore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PacientId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    TotalCost = table.Column<double>(type: "double precision", nullable: false),
                    TreatmentType = table.Column<byte>(type: "smallint", nullable: false),
                    ProthesisCost = table.Column<double>(type: "double precision", nullable: false),
                    Anamnesis = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<byte>(type: "smallint", nullable: false, defaultValue: (byte)1),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Treatments_Pacients_PacientId",
                        column: x => x.PacientId,
                        principalSchema: "PlanejaOdontoCore",
                        principalTable: "Pacients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                schema: "PlanejaOdontoCore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TreatmentId = table.Column<int>(type: "integer", nullable: false),
                    DocumentFile = table.Column<byte[]>(type: "bytea", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_Treatments_TreatmentId",
                        column: x => x.TreatmentId,
                        principalSchema: "PlanejaOdontoCore",
                        principalTable: "Treatments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Installments",
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
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Installments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Installments_Treatments_TreatmentId",
                        column: x => x.TreatmentId,
                        principalSchema: "PlanejaOdontoCore",
                        principalTable: "Treatments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Procedures",
                schema: "PlanejaOdontoCore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TreatmentId = table.Column<int>(type: "integer", nullable: false),
                    DentistId = table.Column<int>(type: "integer", nullable: false),
                    Tooth = table.Column<int>(type: "integer", nullable: false),
                    NeedProthesis = table.Column<bool>(type: "boolean", nullable: false),
                    ProthesisId = table.Column<int>(type: "integer", nullable: true),
                    ProcedureTypeId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Procedures_Dentists_DentistId",
                        column: x => x.DentistId,
                        principalSchema: "PlanejaOdontoCore",
                        principalTable: "Dentists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Procedures_ProcedureTypes_ProcedureTypeId",
                        column: x => x.ProcedureTypeId,
                        principalSchema: "PlanejaOdontoCore",
                        principalTable: "ProcedureTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Procedures_Prothesis_ProthesisId",
                        column: x => x.ProthesisId,
                        principalSchema: "PlanejaOdontoCore",
                        principalTable: "Prothesis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Procedures_Treatments_TreatmentId",
                        column: x => x.TreatmentId,
                        principalSchema: "PlanejaOdontoCore",
                        principalTable: "Treatments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_PacientId",
                schema: "PlanejaOdontoCore",
                table: "Adresses",
                column: "PacientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_TreatmentId",
                schema: "PlanejaOdontoCore",
                table: "Contracts",
                column: "TreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Dentists_FranchiseId",
                schema: "PlanejaOdontoCore",
                table: "Dentists",
                column: "FranchiseId");

            migrationBuilder.CreateIndex(
                name: "IX_Dependants_PacientId",
                schema: "PlanejaOdontoCore",
                table: "Dependants",
                column: "PacientId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationSchedulings_FranchiseId",
                schema: "PlanejaOdontoCore",
                table: "EvaluationSchedulings",
                column: "FranchiseId");

            migrationBuilder.CreateIndex(
                name: "IX_Franchises_FranchiseeId",
                schema: "PlanejaOdontoCore",
                table: "Franchises",
                column: "FranchiseeId");

            migrationBuilder.CreateIndex(
                name: "IX_Installments_TreatmentId",
                schema: "PlanejaOdontoCore",
                table: "Installments",
                column: "TreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacients_FranchiseId",
                schema: "PlanejaOdontoCore",
                table: "Pacients",
                column: "FranchiseId");

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_DentistId",
                schema: "PlanejaOdontoCore",
                table: "Procedures",
                column: "DentistId");

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_ProcedureTypeId",
                schema: "PlanejaOdontoCore",
                table: "Procedures",
                column: "ProcedureTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_ProthesisId",
                schema: "PlanejaOdontoCore",
                table: "Procedures",
                column: "ProthesisId");

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_TreatmentId",
                schema: "PlanejaOdontoCore",
                table: "Procedures",
                column: "TreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcedureSchedulings_DentistId",
                schema: "PlanejaOdontoCore",
                table: "ProcedureSchedulings",
                column: "DentistId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcedureSchedulings_PacientId",
                schema: "PlanejaOdontoCore",
                table: "ProcedureSchedulings",
                column: "PacientId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcedureSchedulings_ProcedureTypeId",
                schema: "PlanejaOdontoCore",
                table: "ProcedureSchedulings",
                column: "ProcedureTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_PacientId",
                schema: "PlanejaOdontoCore",
                table: "Treatments",
                column: "PacientId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_FranchiseId",
                schema: "PlanejaOdontoCore",
                table: "Users",
                column: "FranchiseId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                schema: "PlanejaOdontoCore",
                table: "Users",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adresses",
                schema: "PlanejaOdontoCore");

            migrationBuilder.DropTable(
                name: "Contracts",
                schema: "PlanejaOdontoCore");

            migrationBuilder.DropTable(
                name: "Dependants",
                schema: "PlanejaOdontoCore");

            migrationBuilder.DropTable(
                name: "EvaluationSchedulings",
                schema: "PlanejaOdontoCore");

            migrationBuilder.DropTable(
                name: "Installments",
                schema: "PlanejaOdontoCore");

            migrationBuilder.DropTable(
                name: "Procedures",
                schema: "PlanejaOdontoCore");

            migrationBuilder.DropTable(
                name: "ProcedureSchedulings",
                schema: "PlanejaOdontoCore");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "PlanejaOdontoCore");

            migrationBuilder.DropTable(
                name: "Prothesis",
                schema: "PlanejaOdontoCore");

            migrationBuilder.DropTable(
                name: "Treatments",
                schema: "PlanejaOdontoCore");

            migrationBuilder.DropTable(
                name: "Dentists",
                schema: "PlanejaOdontoCore");

            migrationBuilder.DropTable(
                name: "ProcedureTypes",
                schema: "PlanejaOdontoCore");

            migrationBuilder.DropTable(
                name: "Pacients",
                schema: "PlanejaOdontoCore");

            migrationBuilder.DropTable(
                name: "Franchises",
                schema: "PlanejaOdontoCore");

            migrationBuilder.DropTable(
                name: "Franchisees",
                schema: "PlanejaOdontoCore");
        }
    }
}
