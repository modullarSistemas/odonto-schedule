using PlanejaOdonto.Api.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly PlanejaOdontoDbContext _context;

        public BaseRepository(PlanejaOdontoDbContext context)
        {
            _context = context;
        }
    }
}

