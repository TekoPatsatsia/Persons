using Persons.Infrastructure.Data.Repositories;
using Persons.Infrastructure.Interfaces;
using Persons.Models;

namespace Persons.Infrastructure.Services
{
    public class UserService: IUserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateUserAsync(UserPutModel userModel)
        {
            await _userRepository.CreateUserAsync(userModel);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteUserAsync(id);
        }

        public async Task<List<UserGetModel>> GetUsersAsync()
        {
            return await _userRepository.GetUsersAsync();
        }

        public async Task UpdateUser(int id, UserPutModel model)
        {
            await _userRepository.UpdateUser(id,model);
        }

        
    }
}
