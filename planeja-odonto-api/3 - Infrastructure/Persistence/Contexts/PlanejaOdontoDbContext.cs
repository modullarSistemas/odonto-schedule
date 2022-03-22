using Microsoft.EntityFrameworkCore;
using PlanejaOdonto.Api.Domain.Enums;
using PlanejaOdonto.Api.Domain.Models.DentistAggregate;
using PlanejaOdonto.Api.Domain.Models.FinancialAggregate;
using PlanejaOdonto.Api.Domain.Models.FranchiseeAggregate;
using PlanejaOdonto.Api.Domain.Models.LoginAggregate;
using PlanejaOdonto.Api.Domain.Models.PacientAggregate;
using PlanejaOdonto.Api.Domain.Models.SchedulingAggregate;
using PlanejaOdonto.Api.Domain.Models.TreatmentAggregate;
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

        public DbSet<Scheduling> Schedulings { get; set; }

        public DbSet<Dentist> Dentists { get; set; }

        public DbSet<ProcedureType> ProcedureTypes { get; set; }

        public DbSet<Procedure> Procedures { get; set; }

        public DbSet<Treatment> Treatments { get; set; }

        public DbSet<Income> Income { get; set; }

        public DbSet<Expense> Expense { get; set; }

        public DbSet<ExpenseGroup> ExpenseGroups { get; set; }

        public DbSet<Prothesis> Prothesis { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().ToTable("Users")
                        .Property(f => f.Id)
                        .ValueGeneratedOnAdd();

            modelBuilder.Entity<User>(entity => { entity.HasIndex(e => e.Username).IsUnique(); });


            modelBuilder.Entity<User>().ToTable("Users")
                        .HasIndex(f => f.Username)
                        .IsUnique();

            modelBuilder.Entity<Franchisee>().ToTable("Franchisees")
                        .Property(f => f.Id)
                        .ValueGeneratedOnAdd();

            modelBuilder.Entity<Franchise>().ToTable("Franchises")
                        .Property(f => f.Id)
                        .ValueGeneratedOnAdd();

            modelBuilder.Entity<Pacient>().ToTable("Pacients")
                        .Property(f => f.Id)
                        .ValueGeneratedOnAdd();

            modelBuilder.Entity<Address>().ToTable("Adresses")
                        .Property(f => f.Id)
                        .ValueGeneratedOnAdd();

            modelBuilder.Entity<Dependent>().ToTable("Dependants")
                        .Property(f => f.Id)
                        .ValueGeneratedOnAdd();

            modelBuilder.Entity<Scheduling>().ToTable("Schedulings")
                      .Property(f => f.Id)
                      .ValueGeneratedOnAdd();

            modelBuilder.Entity<Scheduling>().ToTable("Schedulings")
                      .Property(f => f.Status)
                      .HasDefaultValue(SchedulingStatus.New);


            modelBuilder.Entity<Dentist>().ToTable("Dentists")
                      .Property(f => f.Id)
                      .ValueGeneratedOnAdd();


            modelBuilder.Entity<ProcedureType>().ToTable("ProcedureTypes")
                      .Property(f => f.Id)
                      .ValueGeneratedOnAdd();

            modelBuilder.Entity<Treatment>().ToTable("Treatments")
                      .Property(f => f.Id)
                      .ValueGeneratedOnAdd();

            modelBuilder.Entity<Treatment>().ToTable("Treatments")
                      .Property(f => f.Status)
                      .HasDefaultValue(TreatmentStatusEnum.Pendente);

            modelBuilder.Entity<Income>().ToTable("Income")
                      .Property(f => f.Id)
                      .ValueGeneratedOnAdd();

            modelBuilder.Entity<Expense>().ToTable("Expenses")
                      .Property(f => f.Id)
                      .ValueGeneratedOnAdd();

            modelBuilder.Entity<ExpenseGroup>().ToTable("ExpenseGroups")
                      .Property(f => f.Id)
                      .ValueGeneratedOnAdd();


            modelBuilder.Entity<Prothesis>().ToTable("Prothesis")
                      .Property(f => f.Id)
                      .ValueGeneratedOnAdd();

            modelBuilder.Entity<Procedure>().ToTable("Procedures")
                      .Property(f => f.Id)
                      .ValueGeneratedOnAdd();


        }

    }
}
