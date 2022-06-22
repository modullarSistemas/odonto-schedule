using PlanejaOdonto.Api.Application.Services;
using PlanejaOdonto.Api.Application.Services.Communication;
using PlanejaOdonto.Api.Domain.Models.FranchiseeAggregate;
using PlanejaOdonto.Api.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Infrastructure.Services
{
    public class FranchiseService : IFranchiseService
    {
        private readonly IFranchiseeRepository _franchiseeRepository;
        private readonly IFranchiseRepository _franchiseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public FranchiseService(IFranchiseRepository franchiseRepository, IFranchiseeRepository franchiseeRepository, IUnitOfWork unitOfWork)
        {
            _franchiseRepository = franchiseRepository;
            _franchiseeRepository = franchiseeRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<IEnumerable<Franchise>> ListAsync()
        {
            var franchises = await _franchiseRepository.ListAsync();
            return franchises;
        }

        public async Task<FranchiseResponse> SaveAsync(Franchise franchise)
        {
            try
            {
                var existingFranchisee = await _franchiseeRepository.FindByIdAsync(franchise.FranchiseeId);
                if (existingFranchisee == null)
                    return new FranchiseResponse("Franquiador não existe.");

                await _franchiseRepository.AddAsync(franchise);
                await _unitOfWork.CompleteAsync();

                return new FranchiseResponse(franchise);
            }
            catch (Exception ex)
            {
                return new FranchiseResponse($"An error occurred when saving the franchise: {ex.Message}");
            }
        }

        public async Task<FranchiseResponse> UpdateAsync(int id, Franchise franchise)
        {
            var existingFranchise = await _franchiseRepository.FindByIdAsync(id);

            if (existingFranchise == null)
                return new FranchiseResponse("Franquia não encontrada.");


            var existingFranchisee = await _franchiseeRepository.FindByIdAsync(franchise.FranchiseeId);

            if (existingFranchisee == null)
                return new FranchiseResponse("Franquiador não encontrada.");

            existingFranchise.City = franchise.City;
            existingFranchise.District = franchise.District;
            existingFranchise.FranchiseeId = franchise.FranchiseeId;
            existingFranchise.State = franchise.State;


            try
            {
                _franchiseRepository.Update(existingFranchise);
                await _unitOfWork.CompleteAsync();

                return new FranchiseResponse(existingFranchise);
            }
            catch (Exception ex)
            {
                return new FranchiseResponse($"Um erro ocorreu ao atualizar a franquia: {ex.Message}");
            }
        }

        public async Task<FranchiseResponse> DeleteAsync(int id)
        {
            var existingFranchise = await _franchiseRepository.FindByIdAsync(id);

            if (existingFranchise == null)
                return new FranchiseResponse("Franchise not found.");

            try
            {
                _franchiseRepository.Remove(existingFranchise);
                await _unitOfWork.CompleteAsync();

                return new FranchiseResponse(existingFranchise);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new FranchiseResponse($"An error occurred when deleting the franchise: {ex.Message}");
            }
        }


    }
}
 