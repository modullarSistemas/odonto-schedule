
using PlanejaOdonto.Api.Domain.Models.SchedulingAggregate;
using PlanejaOdonto.Api.Domain.Repositories;
using PlanejaOdonto.Api.Domain.Services;
using PlanejaOdonto.Api.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Services
{
    public class SchedulingService : ISchedulingService
    {
        private readonly ISchedulingRepository _schedulingRepository;
        private readonly IPacientRepository _pacientRespository;
        private readonly IDentistRepository _dentistRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SchedulingService(
             ISchedulingRepository schedulingRepository
            , IPacientRepository pacientRespository
            , IDentistRepository dentistRepository
            , IUnitOfWork unitOfWork)
        {
            _schedulingRepository = schedulingRepository;
            _pacientRespository = pacientRespository;
            _dentistRepository = dentistRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Scheduling>> ListAsync()
        {
            // Here I try to get the categories list from the memory cache. If there is no data in cache, the anonymous method will be
            // called, setting the cache to expire one minute ahead and returning the Task that lists the categories from the repository.
            var schedulings = await _schedulingRepository.ListAsync();
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



                await _schedulingRepository.AddAsync(scheduling);
                await _unitOfWork.CompleteAsync();

                return new SchedulingResponse(scheduling);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
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
