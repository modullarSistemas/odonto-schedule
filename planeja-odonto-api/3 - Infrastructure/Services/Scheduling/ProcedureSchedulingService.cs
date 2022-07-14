using PlanejaOdonto.Api.Application.Services;
using PlanejaOdonto.Api.Application.Services.Communication;
using PlanejaOdonto.Api.Application.Services.Scheduling;
using PlanejaOdonto.Api.Domain.Enums;
using PlanejaOdonto.Api.Domain.Models.SchedulingAggregate.Procedure;
using PlanejaOdonto.Api.Domain.Repositories;
using PlanejaOdonto.Api.Domain.Repositories.SchedulingAggregate;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Infrastructure.Services
{
    public class ProcedureSchedulingService : IProcedureSchedulingService
    {
        private readonly IProcedureSchedulingRepository _schedulingRepository;
        private readonly IProcedureTypeRepository _procedureTypeRepository;
        private readonly IPacientRepository _pacientRespository;
        private readonly IDentistRepository _dentistRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;


        public ProcedureSchedulingService(
              IProcedureSchedulingRepository schedulingRepository
            , IProcedureTypeRepository procedureTypeRepository
            , IPacientRepository pacientRespository
            , IDentistRepository dentistRepository
            , IUserRepository userRepository
            , IUnitOfWork unitOfWork)
        {
            _schedulingRepository = schedulingRepository;
            _procedureTypeRepository = procedureTypeRepository;
            _pacientRespository = pacientRespository;
            _dentistRepository = dentistRepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ProcedureScheduling>> ListAsync()
        {
            // Here I try to get the categories list from the memory cache. If there is no data in cache, the anonymous method will be
            // called, setting the cache to expire one minute ahead and returning the Task that lists the categories from the repository.
            var schedulings = await _schedulingRepository.ListAsync();
            return schedulings;
        }

        public async Task<IEnumerable<ProcedureScheduling>> ListByDentistIdAsync(int id)
        {
            var schedulings = await _schedulingRepository.ListByDentistIdAsync(id);
            return schedulings;
        }

        public async Task<IEnumerable<ProcedureScheduling>> ListByFranchiseIdAsync(int id)
        {
            var schedulings = await _schedulingRepository.ListByFranchiseIdAsync(id);
            return schedulings;
        }

        public async Task<ProcedureSchedulingResponse> SaveAsync(ProcedureScheduling scheduling)
        {
            try
            {

                var existingDentist = await _dentistRepository.FindByIdAsync(scheduling.DentistId);
                if (existingDentist == null)
                    return new ProcedureSchedulingResponse("Dentista não está cadastrado no sistema.");

                var existingPacient = await _pacientRespository.FindByIdAsync(scheduling.PacientId);
                if (existingPacient == null)
                    return new ProcedureSchedulingResponse("Paciente não está cadastrado no sistema.");

                var existingUser = await _userRepository.FindByIdAsync(scheduling.ScheduledBy);
                if (existingUser == null)
                    return new ProcedureSchedulingResponse("Usuario não cadastrado no sistema");

                var existingProcedure = await _procedureTypeRepository.FindByIdAsync((int)scheduling.ProcedureTypeId);
                if (existingProcedure == null)
                    return new ProcedureSchedulingResponse("Procedimento não cadastrado no sistema");


                var availableDate = await _schedulingRepository.CheckDateAvailability(scheduling);

                if (availableDate != null)
                    return new ProcedureSchedulingResponse("Horario ja possui agendamento");

                await _schedulingRepository.AddAsync(scheduling);
                await _unitOfWork.CompleteAsync();

                return new ProcedureSchedulingResponse(scheduling);
            }
            catch (Exception ex)
            {
                return new ProcedureSchedulingResponse($"An error occurred when saving the scheduling: {ex.Message}");
            }
        }

        public async Task<ProcedureSchedulingResponse> UpdateAsync(int id, ProcedureScheduling scheduling)
        {
            var existingProcedureScheduling = await _schedulingRepository.FindByIdAsync(id);

            try
            {
                await _unitOfWork.CompleteAsync();

                return new ProcedureSchedulingResponse(existingProcedureScheduling);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ProcedureSchedulingResponse($"Ocorreu um erro ao atualizar o agendamento: {ex.Message}");
            }
        }


        public async Task<ProcedureSchedulingResponse> DeleteAsync(int id)
        {
            var existingProcedureScheduling = await _schedulingRepository.FindByIdAsync(id);

            if (existingProcedureScheduling == null)
                return new ProcedureSchedulingResponse("Agendamento não encontrado.");

            try
            {
                _schedulingRepository.Remove(existingProcedureScheduling);
                await _unitOfWork.CompleteAsync();

                return new ProcedureSchedulingResponse(existingProcedureScheduling);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ProcedureSchedulingResponse($"Ocorreu um erro ao deletar o agendamento: {ex.Message}");
            }
        }

        public async Task<ProcedureSchedulingResponse> UpdateStatus(int id, SchedulingStatus status)
        {
            var existingProcedureScheduling = await _schedulingRepository.FindByIdAsync(id);
            existingProcedureScheduling.Status = status;
            try
            {
                _schedulingRepository.Update(existingProcedureScheduling);
                await _unitOfWork.CompleteAsync();

                return new ProcedureSchedulingResponse(existingProcedureScheduling);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ProcedureSchedulingResponse($"Ocorreu um erro ao atualizar o agendamento: {ex.Message}");
            }



        }


    }
}
