using Microsoft.EntityFrameworkCore;
using PlanejaOdonto.Api.Domain.Enums;
using PlanejaOdonto.Api.Domain.Models.DentistAggregate;
using PlanejaOdonto.Api.Domain.Models.FranchiseeAggregate;
using PlanejaOdonto.Api.Domain.Models.LoginAggregate;
using PlanejaOdonto.Api.Domain.Models.PacientAggregate;
using PlanejaOdonto.Api.Domain.Models.SchedulingAggregate.Evaluation;
using PlanejaOdonto.Api.Domain.Models.SchedulingAggregate.Procedure;
using PlanejaOdonto.Api.Domain.Models.TreatmentAggregate;
using System;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Infrastructure.Persistence.Contexts
{
    public class PlanejaOdontoDbContext : DbContext
    {
        public PlanejaOdontoDbContext(DbContextOptions<PlanejaOdontoDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Franchisee> Franchisees { get; set; }

        public DbSet<Franchise> Franchises { get; set; }

        public DbSet<Pacient> Pacients { get; set; }

        public DbSet<Address> Adresses { get; set; }

        public DbSet<Dependent> Dependants { get; set; }

        public DbSet<ProcedureScheduling> ProcedureSchedulings { get; set; }

        public DbSet<EvaluationScheduling> EvaluationSchedulings { get; set; }

        public DbSet<Dentist> Dentists { get; set; }

        public DbSet<ProcedureType> ProcedureTypes { get; set; }

        public DbSet<Procedure> Procedures { get; set; }

        public DbSet<Installment> Installment { get; set; }

        public DbSet<Treatment> Treatments { get; set; }


        public DbSet<Prothesis> Prothesis { get; set; }

        public DbSet<Contract> Contracts { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.HasDefaultSchema("PlanejaOdontoCore");

            ConfigureUser(modelBuilder);

            ConfigureFranchisee(modelBuilder);

            ConfigureFranchise(modelBuilder);

            ConfigurePacient(modelBuilder);

            ConfigureScheduling(modelBuilder);

            ConfigureDentist(modelBuilder);

            ConfigureTreatment(modelBuilder);

            ConfigureProthesis(modelBuilder);

            ConfigureProcedure(modelBuilder);

            ConfigureContract(modelBuilder);

        }

        private static void ConfigureContract(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contract>().ToTable("Contracts")
                      .Property(f => f.Id)
                      .ValueGeneratedOnAdd();

            modelBuilder.Entity<Contract>().ToTable("Contracts")
                      .Property(f => f.CreatedAt)
                      .HasDefaultValueSql("NOW()");
        }

        private static void ConfigureProthesis(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prothesis>().ToTable("Prothesis")
                      .Property(f => f.Id)
                      .ValueGeneratedOnAdd();
        }



        private static void ConfigureProcedure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Procedure>().ToTable("Procedures")
                      .Property(f => f.Id)
                      .ValueGeneratedOnAdd();

            modelBuilder.Entity<Procedure>().ToTable("Procedures")
                      .Property(f => f.CreatedAt)
                      .HasDefaultValueSql("NOW()");



            modelBuilder.Entity<ProcedureType>().ToTable("ProcedureTypes")
                      .Property(f => f.Id)
                      .ValueGeneratedOnAdd();

            modelBuilder.Entity<ProcedureType>().ToTable("ProcedureTypes")
                      .Property(f => f.CreatedAt)
                      .HasDefaultValueSql("NOW()");
        }

        private static void ConfigureTreatment(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Treatment>().ToTable("Treatments")
                      .Property(f => f.Id)
                      .ValueGeneratedOnAdd();

            modelBuilder.Entity<Treatment>().ToTable("Treatments")
                      .Property(f => f.Status)
                      .HasDefaultValue(TreatmentStatusEnum.Pendente);

            modelBuilder.Entity<Treatment>().ToTable("Treatments")
                      .Property(f => f.CreatedAt)
                      .HasDefaultValueSql("NOW()");


            modelBuilder.Entity<Installment>().ToTable("Installments")
                      .Property(f => f.Id)
                      .ValueGeneratedOnAdd();

            modelBuilder.Entity<Installment>().ToTable("Installments")
                     .Property(f => f.CreatedAt)
                     .HasDefaultValueSql("NOW()");
        }

        private static void ConfigureDentist(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dentist>().ToTable("Dentists")
                      .Property(f => f.Id)
                      .ValueGeneratedOnAdd();

            modelBuilder.Entity<Dentist>().ToTable("Dentists")
                      .Property(f => f.CreatedAt)
                      .HasDefaultValueSql("NOW()");
        }

        private static void ConfigureScheduling(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProcedureScheduling>().ToTable("ProcedureSchedulings")
                      .Property(f => f.Id)
                      .ValueGeneratedOnAdd();

            modelBuilder.Entity<ProcedureScheduling>().ToTable("ProcedureSchedulings")
                      .Property(f => f.Status)
                      .HasDefaultValue(SchedulingStatus.New);

            modelBuilder.Entity<ProcedureScheduling>().ToTable("ProcedureSchedulings")
                      .Property(f => f.CreatedAt)
                      .HasDefaultValueSql("NOW()");


            modelBuilder.Entity<EvaluationScheduling>().ToTable("EvaluationSchedulings")
                       .Property(f => f.Id)
                       .ValueGeneratedOnAdd();

            modelBuilder.Entity<EvaluationScheduling>().ToTable("EvaluationSchedulings")
                      .Property(f => f.Status)
                      .HasDefaultValue(SchedulingStatus.New);

            modelBuilder.Entity<EvaluationScheduling>().ToTable("EvaluationSchedulings")
                      .Property(f => f.CreatedAt)
                      .HasDefaultValueSql("NOW()");
        }

        private static void ConfigurePacient(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pacient>().ToTable("Pacients")
                        .Property(f => f.Id)
                        .ValueGeneratedOnAdd();

            modelBuilder.Entity<Pacient>().ToTable("Pacients")
                        .Property(f => f.CreatedAt)
                        .HasDefaultValueSql("NOW()");

            modelBuilder.Entity<Address>().ToTable("Adresses")
                        .Property(f => f.Id)
                        .ValueGeneratedOnAdd();

            modelBuilder.Entity<Address>().ToTable("Adresses")
                        .Property(f => f.CreatedAt)
                        .HasDefaultValueSql("NOW()");


            modelBuilder.Entity<Dependent>().ToTable("Dependants")
                        .Property(f => f.Id)
                        .ValueGeneratedOnAdd();

            modelBuilder.Entity<Dependent>().ToTable("Dependants")
                        .Property(f => f.CreatedAt)
                        .HasDefaultValueSql("NOW()");
        }

        private static void ConfigureFranchise(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Franchise>().ToTable("Franchises")
                        .Property(f => f.Id)
                        .ValueGeneratedOnAdd();

            modelBuilder.Entity<Franchise>().ToTable("Franchises")
                        .Property(f => f.CreatedAt)
                        .HasDefaultValueSql("NOW()");
        }

        private static void ConfigureFranchisee(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Franchisee>().ToTable("Franchisees")
                        .Property(f => f.Id)
                        .ValueGeneratedOnAdd();


            modelBuilder.Entity<Franchisee>().ToTable("Franchisees")
                        .Property(f => f.CreatedAt)
                        .HasDefaultValueSql("NOW()");
        }

        private static void ConfigureUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users")
                        .Property(f => f.Id)
                        .ValueGeneratedOnAdd();


            modelBuilder.Entity<User>().ToTable("Users")
                        .HasIndex(f => f.Username)
                        .IsUnique();


            modelBuilder.Entity<User>().ToTable("Users")
                        .Property(f => f.CreatedAt)
                        .HasDefaultValueSql("NOW()");
        }
    }
}
