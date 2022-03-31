using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using PlanejaOdonto.Api.Infrastructure.Persistence.Repositories;
using PlanejaOdonto.Api.Authentication;
using PlanejaOdonto.Api.Services;
using PlanejaOdonto.Api.Domain.Repositories;
using PlanejaOdonto.Api.Infrastructure.Persistence.Contexts;
using PlanejaOdonto.Api.Application.Services;
using System;
using System.Globalization;

namespace PlanejaOdonto.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration) 
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();
            services.AddSwaggerGen();
            TokenService.AddJwtAuthentication(services);

            AddRepository(services);
            AddServices(services);

            services.AddAutoMapper(typeof(Startup));

        }

        private static void AddRepository(IServiceCollection services)
        {

            var cString = Configuration.GetConnectionString("PlanejaOdontoDbConnectionString");

            services.AddDbContext<PlanejaOdontoDbContext>(options =>
            {
                options.UseNpgsql(cString);
               // options.LogTo(Console.WriteLine);
            });

            services.AddScoped<IFranchiseeRepository, FranchiseeRepository>();
            services.AddScoped<IFranchiseRepository, FranchiseRepository>();
            services.AddScoped<IPacientRepository, PacientRepository>();
            services.AddScoped<ISchedulingRepository, SchedulingRepository>();
            services.AddScoped<IDentistRepository, DentistRepository>();
            services.AddScoped<IProcedureTypeRepository, ProcedureTypeRepository>();
            services.AddScoped<ITreatmentRepository, TreatmentRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IExpenseRepository, ExpenseRepository>();
            services.AddScoped<IExpenseGroupRepository, ExpenseGroupRepository>();
            services.AddScoped<IIncomeRepository, IncomeRepository>();
            services.AddScoped<IProthesisRepository, ProthesisRepository>();
            services.AddScoped<IProcedureRepository, ProcedureRepository>();
            services.AddScoped<IInstallmentRepository, InstallmentRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IFranchiseService, FranchiseService>();
            services.AddScoped<IPacientService, PacientService>();
            services.AddScoped<ISchedulingService, SchedulingService>();
            services.AddScoped<IDentistService, DentistService>();
            services.AddScoped<IProcedureTypeService, ProcedureTypeService>();
            services.AddScoped<IFranchiseeService, FranchiseeService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ITreatmentService, TreatmentService>();
            services.AddScoped<IFinancialService, FinancialService>(); 
            services.AddScoped<IProthesisService, ProthesisService>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(x =>
                x.AllowAnyOrigin()
                 .AllowAnyMethod()
                 .AllowAnyHeader()
                 );

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Planeja Odonto API");
            });

            
            CultureInfo.CurrentCulture = new CultureInfo("pt-BR");

            //app.UseCustomSwagger();

            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var context = serviceScope.ServiceProvider.GetService<PlanejaOdontoDbContext>();
            context.Database.Migrate();
        }
    }


}
