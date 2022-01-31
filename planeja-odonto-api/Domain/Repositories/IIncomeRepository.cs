using PlanejaOdonto.Api.Domain.Models.FinancialAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Domain.Repositories
{
    public interface IIncomeRepository
    {
        Task<IEnumerable<Income>> ListAsync();
        Task AddAsync(Income income);
        Task<Income> FindByIdAsync(int id);
        void Update(Income income);
        void Remove(Income income);
    }
}
