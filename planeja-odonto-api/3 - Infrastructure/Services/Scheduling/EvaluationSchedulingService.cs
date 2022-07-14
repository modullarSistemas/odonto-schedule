using PlanejaOdonto.Api.Application.Services.Communication;
using PlanejaOdonto.Api.Application.Services.Scheduling;
using PlanejaOdonto.Api.Domain.Enums;
using PlanejaOdonto.Api.Domain.Models.SchedulingAggregate.Evaluation;
using PlanejaOdonto.Api.Domain.Repositories;
using PlanejaOdonto.Api.Domain.Repositories.SchedulingAggregate;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Infrastructure.Services.Scheduling
{
    public class EvaluationSchedulingService : IEvaluationSchedulingService
    {
        private readonly IEvaluationSchedulingRepository _schedulingRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;


        public EvaluationSchedulingService(
              IEvaluationSchedulingRepository schedulingRepository
            , IUserRepository userRepository
            , IUnitOfWork unitOfWork)
        {
            _schedulingRepository = schedulingRepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<EvaluationScheduling>> ListByFranchiseIdAsync(int id)
        {
            var schedulings = await _schedulingRepository.ListByFranchiseIdAsync(id);
            return schedulings;
        }

        public async Task<EvaluationSchedulingResponse> SaveAsync(EvaluationScheduling scheduling)
        {
            try
            {

                var existingUser = await _userRepository.FindByIdAsync(scheduling.ScheduledBy);
                if (existingUser == null)
                    return new EvaluationSchedulingResponse("Usuario não cadastrado no sistema");


                var availableDate = await _schedulingRepository.CheckDateAvailability(scheduling);

                if (availableDate != null)
                    return new EvaluationSchedulingResponse("Horario ja possui agendamento");

                await _schedulingRepository.AddAsync(scheduling);
                await _unitOfWork.CompleteAsync();

                return new EvaluationSchedulingResponse(scheduling);
            }
            catch (Exception ex)
            {
                return new EvaluationSchedulingResponse($"An error occurred when saving the scheduling: {ex.Message}");
            }
        }

        public async Task<EvaluationSchedulingResponse> UpdateAsync(int id, EvaluationScheduling scheduling)
        {
            var existingEvaluationScheduling = await _schedulingRepository.FindByIdAsync(id);

            try
            {
                await _unitOfWork.CompleteAsync();

                return new EvaluationSchedulingResponse(existingEvaluationScheduling);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new EvaluationSchedulingResponse($"Ocorreu um erro ao atualizar o agendamento: {ex.Message}");
            }
        }


        public async Task<EvaluationSchedulingResponse> DeleteAsync(int id)
        {
            var existingEvaluationScheduling = await _schedulingRepository.FindByIdAsync(id);

            if (existingEvaluationScheduling == null)
                return new EvaluationSchedulingResponse("Agendamento não encontrado.");

            try
            {
                _schedulingRepository.Remove(existingEvaluationScheduling);
                await _unitOfWork.CompleteAsync();

                return new EvaluationSchedulingResponse(existingEvaluationScheduling);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new EvaluationSchedulingResponse($"Ocorreu um erro ao deletar o agendamento: {ex.Message}");
            }
        }

         public async Task<EvaluationSchedulingResponse> UpdateStatus(int id , SchedulingStatus status)
        {
            var existingEvaluationScheduling = await _schedulingRepository.FindByIdAsync(id);
            existingEvaluationScheduling.Status = status; 
            try
            {
                 _schedulingRepository.Update(existingEvaluationScheduling);
                await _unitOfWork.CompleteAsync();

                return new EvaluationSchedulingResponse(existingEvaluationScheduling);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new EvaluationSchedulingResponse($"Ocorreu um erro ao atualizar o agendamento: {ex.Message}");
            }

        }


    }
}
