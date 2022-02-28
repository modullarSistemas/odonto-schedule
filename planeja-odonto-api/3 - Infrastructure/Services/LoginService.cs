using AutoMapper;
using PlanejaOdonto.Api.Application.Services;
using PlanejaOdonto.Api.Application.Services.Communication;
using PlanejaOdonto.Api.Domain.Models.LoginAggregate;
using PlanejaOdonto.Api.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;
        private readonly IFranchiseRepository _franchiseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LoginService(IUserRepository userRepository, IFranchiseRepository franchiseRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userRepository = userRepository;
            _franchiseRepository = franchiseRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserResponse> Authenticate(User user)
        {
            // Recupera o usuário
            var existingUser = await _userRepository.FindByUserAndPassword(user);

            // Verifica se o usuário existe
            if (existingUser == null)
                return new UserResponse("Usuario ou senha inválidos");

            // Oculta a senha
            existingUser.Password = "";

            // Retorna os dados
            return new UserResponse(existingUser);
        }
        public async Task<UserResponse> SaveAsync(User user)
        {
            try
            {
                var existingFranchise = await _franchiseRepository.FindByIdAsync(user.FranchiseId);
                if (existingFranchise == null)
                    return new UserResponse("Franquiado não existe.");

                await _userRepository.AddAsync(user);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(user);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new UserResponse($"An error occurred when saving the category: {ex.Message}");
            }
        }

        public async Task<UserResponse> UpdateAsync(int id, User updatedUser)
        {
            var existingUser = await _userRepository.FindByIdAsync(id);

            if (existingUser == null)
                return new UserResponse("Usuario não encontrado.");
            _mapper.Map(updatedUser, existingUser);

            try
            {
                await _unitOfWork.CompleteAsync();

                return new UserResponse(existingUser);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new UserResponse($"Ocorreu um erro ao atualizar o Usuario: {ex.Message}");
            }
        }

        public async Task<UserResponse> DeleteAsync(int id)
        {
            var existingUser = await _userRepository.FindByIdAsync(id);

            if (existingUser == null)
                return new UserResponse("Usuario não encontrado.");

            try
            {
                _userRepository.Remove(existingUser);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(existingUser);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new UserResponse($"Ocorreu um erro ao deletar o Usuario: {ex.Message}");
            }
        }
    }
}
