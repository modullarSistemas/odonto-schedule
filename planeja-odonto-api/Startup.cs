using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using PlanejaOdonto.Api.Persistence.Contexts;
using PlanejaOdonto.Api.Authentication;
using PlanejaOdonto.Api.Extensions;
using PlanejaOdonto.Api.Services;
using PlanejaOdonto.Api.Domain.Services;
using PlanejaOdonto.Api.Domain.Repositories;
using PlanejaOdonto.Api.Persistence.Repositories;

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

            AddDependencyInjection(services);

            services.AddAutoMapper(typeof(Startup));

        }

        private static void AddDependencyInjection(IServiceCollection services)
        {

            var cString = Configuration.GetConnectionString("PlanejaOdontoDbConnectionString");

            services.AddDbContext<PlanejaOdontoDbContext>(options =>
            {
                options.UseNpgsql(cString);
            });

            services.AddScoped<IFranchiseeRepository, FranchiseeRepository>();
            services.AddScoped<IFranchiseeService, FranchiseeService>();

            services.AddScoped<IFranchiseRepository, FranchiseRepository>();
            services.AddScoped<IFranchiseService, FranchiseService>();

            services.AddScoped<IPacientRepository, PacientRepository>();
            services.AddScoped<IPacientService, PacientService>();

            services.AddScoped<ISchedulingRepository, SchedulingRepository>();
            services.AddScoped<ISchedulingService, SchedulingService>();

            services.AddScoped<IDentistRepository, DentistRepository>();
            services.AddScoped<IDentistService, DentistService>();

            services.AddScoped<IProcedureTypeRepository, ProcedureTypeRepository>();
            services.AddScoped<IProcedureTypeService, ProcedureTypeService>();

            services.AddScoped<ITreatmentRepository, TreatmentRepository>();
            services.AddScoped<ITreatmentService, TreatmentService>();

            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
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


            //app.UseCustomSwagger();

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<PlanejaOdontoDbContext>();
                context.Database.Migrate();
            }
        }
    }
}
