using AutoMapper;
using PlanejaOdonto.Api.Application.Services;
using PlanejaOdonto.Api.Application.Services.Communication;
using PlanejaOdonto.Api.Domain.Models.PacientAggregate;
using PlanejaOdonto.Api.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Infrastructure.Services
{
    public class PacientService : IPacientService
    {
        private readonly IPacientRepository _pacientRepository;
        private readonly IFranchiseRepository _franchiseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PacientService(IPacientRepository pacientRepository, IFranchiseRepository franchiseRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _pacientRepository = pacientRepository;
            _franchiseRepository = franchiseRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Pacient>> ListPacientByFranchiseIdAsync(int id)
        {
            var pacients = await _pacientRepository.ListPacientByFranchiseIdAsync(id);

            return pacients;
        }
        public async Task<Pacient> GetById(int id)
        {
            var pacient = await _pacientRepository.FindByIdAsync(id);

            return pacient;
        }



        public async Task<PacientResponse> SaveAsync(Pacient pacient)
        {   
            try
            {
                var existingFranchise = await _franchiseRepository.FindByIdAsync(pacient.FranchiseId);
                if (existingFranchise == null)
                    return new PacientResponse("Franquiado não existe.");

                await _pacientRepository.AddAsync(pacient);
                await _unitOfWork.CompleteAsync();

                return new PacientResponse(pacient);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new PacientResponse($"An error occurred when saving the category: {ex.Message}");
            }
        }

        public async Task<PacientResponse> UpdateAsync(int id, Pacient updatedPacient)
        {
            var existingPacient = await _pacientRepository.FindByIdAsync(id);

            if (existingPacient == null)
                return new PacientResponse("Paciente não encontrado.");
            _mapper.Map(updatedPacient, existingPacient);

            try
            {
                await _unitOfWork.CompleteAsync();

                return new PacientResponse(existingPacient);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new PacientResponse($"Ocorreu um erro ao atualizar o paciente: {ex.Message}");
            }
        }

        public async Task<PacientResponse> DeleteAsync(int id)
        {
            var existingPacient = await _pacientRepository.FindByIdAsync(id);

            if (existingPacient == null)
                return new PacientResponse("Paciente não encontrado.");

            try
            {
                _pacientRepository.Remove(existingPacient);
                await _unitOfWork.CompleteAsync();

                return new PacientResponse(existingPacient);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new PacientResponse($"Ocorreu um erro ao deletar o paciente: {ex.Message}");
            }
        }

    }
}
