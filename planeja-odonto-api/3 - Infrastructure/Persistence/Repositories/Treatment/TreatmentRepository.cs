﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PlanejaOdonto.Api.Domain.Enums;
using PlanejaOdonto.Api.Domain.Models.TreatmentAggregate;
using PlanejaOdonto.Api.Domain.Repositories;
using PlanejaOdonto.Api.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Infrastructure.Persistence.Repositories
{
    public class TreatmentRepository : BaseRepository, ITreatmentRepository
    {
        public TreatmentRepository(PlanejaOdontoDbContext context, IConfiguration configuration) : base(context, configuration) { }

        public async Task<IEnumerable<Treatment>> ListAsync()
        {
            return await _context.Treatments
                                 .Include(x => x.Pacient)
                                 .Include(x => x.Procedures)
                                    .ThenInclude(y => y.ProcedureType)
                                  .Include(y => y.Procedures)
                                    .ThenInclude(x => x.Prothesis)
                                 .Include(x => x.Installments)
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Treatment>> ListByPacientIdAsync(int id)
        {
            return await _context.Treatments
                                 .Include(x => x.Pacient)
                                 .Include(x => x.Procedures)
                                    .ThenInclude(y => y.ProcedureType)
                                  .Include(y => y.Procedures)
                                    .ThenInclude(x => x.Prothesis)
                                 .Include(x => x.Installments)
                                 .Where(x => x.Pacient.Id == id)
                                 .AsNoTracking()
                                 .ToListAsync();

        }
        public async Task<IEnumerable<Treatment>> ListByFranchiseIdAsync(int id)
        {
            return await _context.Treatments
                                 .Include(x => x.Pacient)
                                 .Include(x => x.Procedures)
                                    .ThenInclude(y => y.ProcedureType)
                                  .Include(y => y.Procedures)
                                    .ThenInclude(x => x.Prothesis)
                                 .Include(x => x.Installments)
                                 .AsNoTracking()
                                 .Where(x => x.Pacient.FranchiseId == id)
                                 .ToListAsync();
        }

        public async Task AddAsync(Treatment franchisee)
        {
            await _context.Treatments.AddAsync(franchisee);
        }

        public async Task<Treatment> FindByIdAsync(int id)
        {
            return await _context.Treatments
                                 .Include(x => x.Pacient)
                                 .Include(x => x.Procedures)
                                    .ThenInclude(y => y.ProcedureType)
                                  .Include(y => y.Procedures)
                                    .ThenInclude(x => x.Prothesis)
                                 .Include(y => y.Procedures)
                                 .Include(x => x.Installments)
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Treatment> FindByIdTrackingAsync(int id)
        {
            return await _context.Treatments
                                 .Include(x => x.Pacient)
                                 .Include(x => x.Procedures)
                                    .ThenInclude(y => y.ProcedureType)
                                  .Include(y => y.Procedures)
                                    .ThenInclude(x => x.Prothesis)
                                 .Include(x => x.Installments)
                                 .FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Update(Treatment franchisee)
        {
            _context.Treatments.Update(franchisee);
        }

        public void Remove(Treatment franchisee)
        {
            _context.Treatments.Remove(franchisee);
        }

        public async Task<IEnumerable<Treatment>> ListOrthodonticsByPacientIdAsync(int id)
        {
            return await _context.Treatments
                                .Where(x => x.TreatmentType == TreatmentTypeEnum.Ortondia && x.PacientId == id)
                                .AsNoTracking()
                                .ToListAsync();
        }

        public async Task<IEnumerable<Treatment>> ListGeneralClinicByPacientIdAsync(int id)
        {
            return await _context.Treatments
                                .Where(x => x.TreatmentType == TreatmentTypeEnum.ClinicoGeral && x.PacientId == id)
                                .AsNoTracking()
                                .ToListAsync();
        }

        public async Task<IEnumerable<Treatment>> ListImplantologyByPacientIdAsync(int id)
        {
            return await _context.Treatments
                                .Where(x => x.TreatmentType == TreatmentTypeEnum.Implantodontia && x.PacientId == id)
                                .AsNoTracking()
                                .ToListAsync();
        }

        public async Task<IEnumerable<Treatment>> ListFacialHarmonizationByPacientIdAsync(int id)
        {
            return await _context.Treatments
                                .Where(x => x.TreatmentType == TreatmentTypeEnum.HarmonizacaoFacial && x.PacientId == id)
                                .AsNoTracking()
                                .ToListAsync();
        }



        public async Task<IEnumerable<ProcedureType>> ListGeneralClinictAsync()
        {
            return await _context.ProcedureTypes
                     .Where(x => x.TreatmentType == TreatmentTypeEnum.ClinicoGeral)
                     .AsNoTracking()
                     .ToListAsync();
        }

        public async Task<IEnumerable<ProcedureType>> ListImplantologyAsync()
        {

            return await _context.ProcedureTypes
                     .Where(x => x.TreatmentType == TreatmentTypeEnum.Implantodontia)
                     .AsNoTracking()
                     .ToListAsync();
        }

        public async Task<IEnumerable<ProcedureType>> ListFacialHarmonizationAsync()
        {

            return await _context.ProcedureTypes
                     .Where(x => x.TreatmentType == TreatmentTypeEnum.HarmonizacaoFacial)
                     .AsNoTracking()
                     .ToListAsync();
        }
    }
}
