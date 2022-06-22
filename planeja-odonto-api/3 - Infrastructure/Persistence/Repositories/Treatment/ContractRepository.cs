using Microsoft.Extensions.Configuration;
using PlanejaOdonto.Api.Domain.Models.TreatmentAggregate;
using PlanejaOdonto.Api.Domain.Repositories;
using PlanejaOdonto.Api.Infrastructure.Persistence.Contexts;
using System;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Infrastructure.Persistence.Repositories
{
    public class ContractRepository : BaseRepository, IContractRepository
    {

        public ContractRepository(PlanejaOdontoDbContext context, IConfiguration configuration) : base(context, configuration) { }


        public async Task AddAsync(Contract contract)
        {
            await _context.Contracts.AddAsync(contract);
        }

        public async Task<Contract> FindByIdAsync(int id)
        {
            return await _context.Contracts.FindAsync(id);
        }

        public void Update(Contract contract)
        {
            _context.Contracts.Update(contract);
        }

        public void Remove(Contract contract)
        {
            _context.Contracts.Remove(contract);
        }
    }
}
