﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PlanejaOdonto.Api.Infrastructure.Persistence.Contexts;

namespace PlanejaOdonto.Api.Migrations
{
    [DbContext(typeof(PlanejaOdontoDbContext))]
    [Migration("20220705075221_contract-document-file")]
    partial class contractdocumentfile
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("PlanejaOdonto.Api.Domain.Models.DentistAggregate.Dentist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<byte>("Category")
                        .HasColumnType("smallint");

                    b.Property<double>("Comission")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<int>("FranchiseId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FranchiseId");

                    b.ToTable("Dentists");
                });

            modelBuilder.Entity("PlanejaOdonto.Api.Domain.Models.FinancialAggregate.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("ExpenseGroupId")
                        .HasColumnType("integer");

                    b.Property<int>("FranchiseId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<double>("Value")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("ExpenseGroupId");

                    b.HasIndex("FranchiseId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("PlanejaOdonto.Api.Domain.Models.FinancialAggregate.ExpenseGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("ExpenseGroups");
                });

            modelBuilder.Entity("PlanejaOdonto.Api.Domain.Models.FinancialAggregate.Income", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("FranchiseId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<double>("Value")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("FranchiseId");

                    b.ToTable("Income");
                });

            modelBuilder.Entity("PlanejaOdonto.Api.Domain.Models.FranchiseeAggregate.Franchise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("District")
                        .HasColumnType("text");

                    b.Property<int>("FranchiseeId")
                        .HasColumnType("integer");

                    b.Property<string>("State")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("FranchiseeId");

                    b.ToTable("Franchises");
                });

            modelBuilder.Entity("PlanejaOdonto.Api.Domain.Models.FranchiseeAggregate.Franchisee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Franchisees");
                });

            modelBuilder.Entity("PlanejaOdonto.Api.Domain.Models.LoginAggregate.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<int>("FranchiseId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("FranchiseId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PlanejaOdonto.Api.Domain.Models.PacientAggregate.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Complement")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("District")
                        .HasColumnType("text");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<int>("PacientId")
                        .HasColumnType("integer");

                    b.Property<string>("State")
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ZipCode")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PacientId")
                        .IsUnique();

                    b.ToTable("Adresses");
                });

            modelBuilder.Entity("PlanejaOdonto.Api.Domain.Models.PacientAggregate.Dependent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Gender")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("PacientId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("PacientId");

                    b.ToTable("Dependants");
                });

            modelBuilder.Entity("PlanejaOdonto.Api.Domain.Models.PacientAggregate.Pacient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CPF")
                        .HasColumnType("text");

                    b.Property<string>("CivilState")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<int>("FranchiseId")
                        .HasColumnType("integer");

                    b.Property<string>("Gender")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("Profession")
                        .HasColumnType("text");

                    b.Property<string>("Rg")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("FranchiseId");

                    b.ToTable("Pacients");
                });

            modelBuilder.Entity("PlanejaOdonto.Api.Domain.Models.SchedulingAggregate.Scheduling", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<int>("DentistId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("PacientId")
                        .HasColumnType("integer");

                    b.Property<int?>("ProcedureTypeId")
                        .HasColumnType("integer");

                    b.Property<int>("ScheduledBy")
                        .HasColumnType("integer");

                    b.Property<byte>("SchedulingType")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<byte>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasDefaultValue((byte)1);

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("DentistId");

                    b.HasIndex("PacientId");

                    b.HasIndex("ProcedureTypeId");

                    b.ToTable("Schedulings");
                });

            modelBuilder.Entity("PlanejaOdonto.Api.Domain.Models.TreatmentAggregate.Contract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<byte[]>("DocumentFile")
                        .HasColumnType("bytea");

                    b.Property<int>("TreatmentId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("TreatmentId");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("PlanejaOdonto.Api.Domain.Models.TreatmentAggregate.Installment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("Cost")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<DateTime>("Due")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("Payday")
                        .HasColumnType("timestamp without time zone");

                    b.Property<byte>("PaymentMethod")
                        .HasColumnType("smallint");

                    b.Property<int>("TreatmentId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("TreatmentId");

                    b.ToTable("Installments");
                });

            modelBuilder.Entity("PlanejaOdonto.Api.Domain.Models.TreatmentAggregate.Procedure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<int>("DentistId")
                        .HasColumnType("integer");

                    b.Property<bool>("NeedProthesis")
                        .HasColumnType("boolean");

                    b.Property<int>("ProcedureTypeId")
                        .HasColumnType("integer");

                    b.Property<int?>("ProthesisId")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("Tooth")
                        .HasColumnType("integer");

                    b.Property<int>("TreatmentId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("DentistId");

                    b.HasIndex("ProcedureTypeId");

                    b.HasIndex("ProthesisId");

                    b.HasIndex("TreatmentId");

                    b.ToTable("Procedures");
                });

            modelBuilder.Entity("PlanejaOdonto.Api.Domain.Models.TreatmentAggregate.ProcedureType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("Cost")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<byte>("TreatmentType")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("ProcedureTypes");
                });

            modelBuilder.Entity("PlanejaOdonto.Api.Domain.Models.TreatmentAggregate.Prothesis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("Cost")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Prothesis");
                });

            modelBuilder.Entity("PlanejaOdonto.Api.Domain.Models.TreatmentAggregate.Treatment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Anamnesis")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("PacientId")
                        .HasColumnType("integer");

                    b.Property<double>("ProthesisCost")
                        .HasColumnType("double precision");

                    b.Property<byte>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasDefaultValue((byte)1);

                    b.Property<double>("TotalCost")
                        .HasColumnType("double precision");

                    b.Property<byte>("TreatmentType")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("PacientId");

                    b.ToTable("Treatments");
                });

            modelBuilder.Entity("PlanejaOdonto.Api.Domain.Models.DentistAggregate.Dentist", b =>
                {
                    b.HasOne("PlanejaOdonto.Api.Domain.Models.FranchiseeAggregate.Franchise", "Franchise")
                        .WithMany()
                        .HasForeignKey("FranchiseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Franchise");
                });

            modelBuilder.Entity("PlanejaOdonto.Api.Domain.Models.FinancialAggregate.Expense", b =>
                {
                    b.HasOne("PlanejaOdonto.Api.Domain.Models.FinancialAggregate.ExpenseGroup", "ExpenseGroup")
                        .WithMany()
                        .HasForeignKey("ExpenseGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlanejaOdonto.Api.Domain.Models.FranchiseeAggregate.Franchise", "Franchise")
                        .WithMany()
                        .HasForeignKey("FranchiseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExpenseGroup");

                    b.Navigation("Franchise");
                });

            modelBuilder.Entity("PlanejaOdonto.Api.Domain.Models.FinancialAggregate.Income", b =>
                {
                    b.HasOne("PlanejaOdonto.Api.Domain.Models.FranchiseeAggregate.Franchise", "Franchise")
                        .WithMany()
                        .HasForeignKey("FranchiseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Franchise");
                });

            modelBuilder.Entity("PlanejaOdonto.Api.Domain.Models.FranchiseeAggregate.Franchise", b =>
                {
                    b.HasOne("PlanejaOdonto.Api.Domain.Models.FranchiseeAggregate.Franchisee", "Franchisee")
                        .WithMany("Franchises")
                        .HasForeignKey("FranchiseeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Franchisee");
                });

            modelBuilder.Entity("PlanejaOdonto.Api.Domain.Models.LoginAggregate.User", b =>
                {
                    b.HasOne("PlanejaOdonto.Api.Domain.Models.FranchiseeAggregate.Franchise", "Franchise")
                        .WithMany()
                        .HasForeignKey("FranchiseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Franchise");
                });

            modelBuilder.Entity("PlanejaOdonto.Api.Domain.Models.PacientAggregate.Address", b =>
                {
                    b.HasOne("PlanejaOdonto.Api.Domain.Models.PacientAggregate.Pacient", "Pacient")
                        .WithOne("Address")
                        .HasForeignKey("PlanejaOdonto.Api.Domain.Models.PacientAggregate.Address", "PacientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pacient");
                });

            modelBuilder.Entity("PlanejaOdonto.Api.Domain.Models.PacientAggregate.Dependent", b =>
                {
                    b.HasOne("PlanejaOdonto.Api.Domain.Models.PacientAggregate.Pacient", "Pacient")
                        .WithMany("Dependants")
                        .HasForeignKey("PacientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pacient");
                });

            modelBuilder.Entity("PlanejaOdonto.Api.Domain.Models.PacientAggregate.Pacient", b =>
                {
                    b.HasOne("PlanejaOdonto.Api.Domain.Models.FranchiseeAggregate.Franchise", "Franchise")
                        .WithMany()
                        .HasForeignKey("FranchiseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Franchise");
                });

            modelBuilder.Entity("PlanejaOdonto.Api.Domain.Models.SchedulingAggregate.Scheduling", b =>
                {
                    b.HasOne("PlanejaOdonto.Api.Domain.Models.DentistAggregate.Dentist", "Dentist")
                        .WithMany()
                        .HasForeignKey("DentistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlanejaOdonto.Api.Domain.Models.PacientAggregate.Pacient", "Pacient")
                        .WithMany()
                        .HasForeignKey("PacientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlanejaOdonto.Api.Domain.Models.TreatmentAggregate.ProcedureType", "ProcedureType")
                        .WithMany()
                        .HasForeignKey("ProcedureTypeId");

                    b.Navigation("Dentist");

                    b.Navigation("Pacient");

                    b.Navigation("ProcedureType");
                });

            modelBuilder.Entity("PlanejaOdonto.Api.Domain.Models.TreatmentAggregate.Contract", b =>
                {
                    b.HasOne("PlanejaOdonto.Api.Domain.Models.TreatmentAggregate.Treatment", "Treatment")
                        .WithMany()
                        .HasForeignKey("TreatmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Treatment");
                });

            modelBuilder.Entity("PlanejaOdonto.Api.Domain.Models.TreatmentAggregate.Installment", b =>
                {
                    b.HasOne("PlanejaOdonto.Api.Domain.Models.TreatmentAggregate.Treatment", "Treatment")
                        .WithMany("Installments")
                        .HasForeignKey("TreatmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Treatment");
                });

            modelBuilder.Entity("PlanejaOdonto.Api.Domain.Models.TreatmentAggregate.Procedure", b =>
                {
                    b.HasOne("PlanejaOdonto.Api.Domain.Models.DentistAggregate.Dentist", "Dentist")
                        .WithMany()
                        .HasForeignKey("DentistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlanejaOdonto.Api.Domain.Models.TreatmentAggregate.ProcedureType", "ProcedureType")
                        .WithMany()
                        .HasForeignKey("ProcedureTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlanejaOdonto.Api.Domain.Models.TreatmentAggregate.Prothesis", "Prothesis")
                        .WithMany()
                        .HasForeignKey("ProthesisId");

                    b.HasOne("PlanejaOdonto.Api.Domain.Models.TreatmentAggregate.Treatment", "Treatment")
                        .WithMany("Procedures")
                        .HasForeignKey("TreatmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dentist");

                    b.Navigation("ProcedureType");

                    b.Navigation("Prothesis");

                    b.Navigation("Treatment");
                });

            modelBuilder.Entity("PlanejaOdonto.Api.Domain.Models.TreatmentAggregate.Treatment", b =>
                {
                    b.HasOne("PlanejaOdonto.Api.Domain.Models.PacientAggregate.Pacient", "Pacient")
                        .WithMany()
                        .HasForeignKey("PacientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pacient");
                });

            modelBuilder.Entity("PlanejaOdonto.Api.Domain.Models.FranchiseeAggregate.Franchisee", b =>
                {
                    b.Navigation("Franchises");
                });

            modelBuilder.Entity("PlanejaOdonto.Api.Domain.Models.PacientAggregate.Pacient", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("Dependants");
                });

            modelBuilder.Entity("PlanejaOdonto.Api.Domain.Models.TreatmentAggregate.Treatment", b =>
                {
                    b.Navigation("Installments");

                    b.Navigation("Procedures");
                });
#pragma warning restore 612, 618
        }
    }
}
