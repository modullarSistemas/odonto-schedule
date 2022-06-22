using AutoMapper;
using PlanejaOdonto.Api.Application.Services;
using PlanejaOdonto.Api.Application.Services.Communication;
using PlanejaOdonto.Api.Domain.Models.DentistAggregate;
using PlanejaOdonto.Api.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Infrastructure.Services
{
    public class DentistService : IDentistService
    {
        private readonly IDentistRepository _dentistRepository;
        private readonly IFranchiseRepository _franchiseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DentistService(IDentistRepository dentistRepository, IFranchiseRepository franchiseRepository, IUnitOfWork unitOfWork)
        {
            _dentistRepository = dentistRepository;
            _franchiseRepository = franchiseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Dentist>> ListAsync()
        {
            var dentists = await _dentistRepository.ListAsync();

            return dentists;
        }

        public async Task<IEnumerable<Dentist>> ListByFranchiseIdAsync(int id)
        {
            var dentists = await _dentistRepository.ListByFranchiseIdAsync(id);

            return dentists;
        }

        public async Task<Dentist> GetById(int id)
        {
            var dentist = await _dentistRepository.FindByIdAsync(id);

            return dentist;
        }

        public async Task<Dentist> GetByUserId(int id)
        {
            var dentist = await _dentistRepository.FindByUserIdAsync(id);

            return dentist;
        }

        public async Task<DentistResponse> SaveAsync(Dentist dentist)
        {
            try
            {
                var existingFranchise = await _franchiseRepository.FindByIdAsync(dentist.FranchiseId);
                if (existingFranchise == null)
                    return new DentistResponse("Franquiado não existe.");

                await _dentistRepository.AddAsync(dentist);
                await _unitOfWork.CompleteAsync();

                return new DentistResponse(dentist);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new DentistResponse($"An error occurred when saving the category: {ex.Message}");
            }
        }

        public async Task<DentistResponse> UpdateAsync(int id, Dentist updatedDentist)
        {
            var existingDentist = await _dentistRepository.FindByIdAsync(id);

            if (existingDentist == null)
                return new DentistResponse("Dentista não encontrado.");

            var existingFranchise = _franchiseRepository.FindByIdAsync(updatedDentist.FranchiseId);
            if (existingFranchise == null)
                return new DentistResponse("Franquia não existe.");

            UpdateDentist(updatedDentist, existingDentist);

            try
            {
                await _unitOfWork.CompleteAsync();

                return new DentistResponse(existingDentist);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new DentistResponse($"Ocorreu um erro ao atualizar o dentiste: {ex.Message}");
            }
        }

        private static void UpdateDentist(Dentist updatedDentist, Dentist existingDentist)
        {
            existingDentist.Category = updatedDentist.Category;
            existingDentist.FranchiseId = updatedDentist.FranchiseId;
            existingDentist.Name = updatedDentist.Name;
        }

        public async Task<DentistResponse> DeleteAsync(int id)
        {
            var existingDentist = await _dentistRepository.FindByIdAsync(id);

            if (existingDentist == null)
                return new DentistResponse("Dentiste não encontrado.");

            try
            {
                _dentistRepository.Remove(existingDentist);
                await _unitOfWork.CompleteAsync();

                return new DentistResponse(existingDentist);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new DentistResponse($"Ocorreu um erro ao deletar o dentiste: {ex.Message}");
            }
        }


    }
}
