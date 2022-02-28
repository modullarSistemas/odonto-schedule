﻿using PlanejaOdonto.Api.Domain.Models.SchedulingAggregate;
using PlanejaOdonto.Api.Application.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Application.Services
{
    public interface ISchedulingService
    {
        Task<IEnumerable<Scheduling>> ListAsync();
        Task<SchedulingResponse> SaveAsync(Scheduling category);
        Task<SchedulingResponse> UpdateAsync(int id, Scheduling category);
        Task<SchedulingResponse> DeleteAsync(int id);
    }
}