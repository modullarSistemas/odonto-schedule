using PlanejaOdonto.Api.Application.Services;
using PlanejaOdonto.Api.Application.Services.Communication;
using PlanejaOdonto.Api.Domain.Models.FranchiseeAggregate;
using PlanejaOdonto.Api.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Infrastructure.Services
{
    public class FranchiseeService : IFranchiseeService
    {

        private readonly IFranchiseeRepository _franchiseeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public FranchiseeService(IFranchiseeRepository franchiseeRepository, IUnitOfWork unitOfWork)
        {
            _franchiseeRepository = franchiseeRepository;
            _unitOfWork = unitOfWork;
        }



        public async Task<IEnumerable<Franchisee>> ListAsync()
        {
            // Here I try to get the categories list from the memory cache. If there is no data in cache, the anonymous method will be
            // called, setting the cache to expire one minute ahead and returning the Task that lists the categories from the repository.
            var franchisees = await _franchiseeRepository.ListAsync();
            return franchisees;
        }

        public async Task<FranchiseeResponse> SaveAsync(Franchisee franchisee)
        {
            try
            {
                await _franchiseeRepository.AddAsync(franchisee);
                await _unitOfWork.CompleteAsync();

                return new FranchiseeResponse(franchisee);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new FranchiseeResponse($"An error occurred when saving the franchisee: {ex.Message}");
            }
        }

        public async Task<FranchiseeResponse> UpdateAsync(int id, Franchisee franchisee)
        {
            var existingFranchisee = await _franchiseeRepository.FindByIdAsync(id);

            if (existingFranchisee == null)
                return new FranchiseeResponse("Franchisee not found.");

            existingFranchisee.Name = franchisee.Name;
            existingFranchisee.Email = franchisee.Email;
            existingFranchisee.Phone = franchisee.Phone;

            try
            {
                await _unitOfWork.CompleteAsync();

                return new FranchiseeResponse(existingFranchisee);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new FranchiseeResponse($"An error occurred when updating the franchisee: {ex.Message}");
            }
        }


        public async Task<FranchiseeResponse> DeleteAsync(int id)
        {
            var existingFranchisee = await _franchiseeRepository.FindByIdAsync(id);

            if (existingFranchisee == null)
                return new FranchiseeResponse("Franchisee not found.");

            try
            {
                _franchiseeRepository.Remove(existingFranchisee);
                await _unitOfWork.CompleteAsync();

                return new FranchiseeResponse(existingFranchisee);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new FranchiseeResponse($"An error occurred when deleting the franchisee: {ex.Message}");
            }
        }


    }
}
