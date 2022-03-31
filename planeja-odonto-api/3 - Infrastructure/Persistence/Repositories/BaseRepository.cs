using Microsoft.Extensions.Configuration;
using PlanejaOdonto.Api.Infrastructure.Persistence.Contexts;

namespace PlanejaOdonto.Api.Infrastructure.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly PlanejaOdontoDbContext _context;
        public static IConfiguration Configuration { get; private set; }

        public BaseRepository(PlanejaOdontoDbContext context, IConfiguration configuration)
        {
            Configuration = configuration;
            _context = context;
        }


        public string GetConnection()
        {
            return Configuration.GetConnectionString("PlanejaOdontoDbConnectionString");
        }

    }
}

