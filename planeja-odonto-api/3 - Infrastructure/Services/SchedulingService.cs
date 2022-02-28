using PlanejaOdonto.Api.Application.Services;
using PlanejaOdonto.Api.Application.Services.Communication;
using PlanejaOdonto.Api.Domain.Enums;
using PlanejaOdonto.Api.Domain.Models.SchedulingAggregate;
using PlanejaOdonto.Api.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Services
{
    public class SchedulingService : ISchedulingService
    {
        private readonly ISchedulingRepository _schedulingRepository;
        private readonly IProcedureTypeRepository _procedureTypeRepository;
        private readonly IPacientRepository _pacientRespository;
        private readonly IDentistRepository _dentistRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;


        public SchedulingService(
              ISchedulingRepository schedulingRepository
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

        public async Task<IEnumerable<Scheduling>> ListAsync()
        {
            // Here I try to get the categories list from the memory cache. If there is no data in cache, the anonymous method will be
            // called, setting the cache to expire one minute ahead and returning the Task that lists the categories from the repository.
            var schedulings = await _schedulingRepository.ListAsync();
            return schedulings;
        }

        public async Task<IEnumerable<Scheduling>> ListByDentistIdAsync(int id)
        {
            var schedulings = await _schedulingRepository.ListByDentistIdAsync(id);
            return schedulings;
        }

        public async Task<IEnumerable<Scheduling>> ListByFranchiseIdAsync(int id)
        {
            var schedulings = await _schedulingRepository.ListByFranchiseIdAsync(id);
            return schedulings;
        }

        public async Task<SchedulingResponse> SaveAsync(Scheduling scheduling)
        {
            try
            {

                var existingDentist = await _dentistRepository.FindByIdAsync(scheduling.DentistId);
                if (existingDentist == null)
                    return new SchedulingResponse("Dentista não está cadastrado no sistema.");

                var existingPacient = await _pacientRespository.FindByIdAsync(scheduling.PacientId);
                if (existingPacient == null)
                    return new SchedulingResponse("Paciente não está cadastrado no sistema.");

                var existingUser = await _userRepository.FindByIdAsync(scheduling.ScheduledBy);
                if (existingUser == null)
                    return new SchedulingResponse("Usuario não cadastrado no sistema");

                if (scheduling.SchedulingType == SchedulingType.Procedimento)
                {
                    var existingProcedure = await _procedureTypeRepository.FindByIdAsync(scheduling.ProcedureTypeId);
                    if (existingProcedure == null)
                        return new SchedulingResponse("Usuario não cadastrado no sistema");
                }

                var availableDate = await _schedulingRepository.CheckDateAvailability(scheduling);

                if (availableDate != null)
                    return new SchedulingResponse("Horario ja possui agendamento");

                await _schedulingRepository.AddAsync(scheduling);
                await _unitOfWork.CompleteAsync();

                return new SchedulingResponse(scheduling);
            }
            catch (Exception ex)
            {
                return new SchedulingResponse($"An error occurred when saving the scheduling: {ex.Message}");
            }
        }

        public async Task<SchedulingResponse> UpdateAsync(int id, Scheduling scheduling)
        {
            var existingScheduling = await _schedulingRepository.FindByIdAsync(id);

            try
            {
                await _unitOfWork.CompleteAsync();

                return new SchedulingResponse(existingScheduling);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SchedulingResponse($"Ocorreu um erro ao atualizar o agendamento: {ex.Message}");
            }
        }


        public async Task<SchedulingResponse> DeleteAsync(int id)
        {
            var existingScheduling = await _schedulingRepository.FindByIdAsync(id);

            if (existingScheduling == null)
                return new SchedulingResponse("Agendamento não encontrado.");

            try
            {
                _schedulingRepository.Remove(existingScheduling);
                await _unitOfWork.CompleteAsync();

                return new SchedulingResponse(existingScheduling);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SchedulingResponse($"Ocorreu um erro ao deletar o agendamento: {ex.Message}");
            }
        }


    }
}
