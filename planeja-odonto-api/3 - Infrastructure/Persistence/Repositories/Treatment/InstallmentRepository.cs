﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PlanejaOdonto.Api.Domain.Models.TreatmentAggregate;
using PlanejaOdonto.Api.Domain.Repositories;
using PlanejaOdonto.Api.Infrastructure.Persistence.Contexts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Infrastructure.Persistence.Repositories
{
    public class InstallmentRepository : BaseRepository, IInstallmentRepository
    {
        public InstallmentRepository(PlanejaOdontoDbContext context,IConfiguration configuration) : base(context, configuration) { }

        public async Task<IEnumerable<Installment>> ListAsync()
        {
            return await _context.Installment
                                 .AsNoTracking()
                                 .ToListAsync();

            // AsNoTracking tells EF Core it doesn't need to track changes on listed entities. Disabling entity
            // tracking makes the code a little faster
        }

        public async Task<IEnumerable<Installment>> ListByTreatmentIdAsync(int treatmentId)
        {
            return await _context.Installment
                                 .Where(x => x.TreatmentId == treatmentId)
                                 .AsNoTracking()
                                 .ToListAsync()
                                 ;
        }

        public async Task AddAsync(Installment franchisee)
        {
            var result = await _context.Installment.AddAsync(franchisee);
        }

        public async Task<Installment> FindByIdAsync(int id)
        {
            return await _context.Installment.FindAsync(id);
        }

        public void Update(Installment franchisee)
        {
            _context.Installment.Update(franchisee);
        }

        public void Remove(Installment franchisee)
        {
            _context.Installment.Remove(franchisee);
        }
    }
}