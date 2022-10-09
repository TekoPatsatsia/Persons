using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persons.Models;

namespace Persons.Infrastructure.Interfaces
{
    public interface IUserService
    {
        Task<List<UserGetModel>> GetUsersAsync();
        Task CreateUserAsync(UserPutModel userModel);
        Task UpdateUser(int id, UserPutModel model);
        Task DeleteUserAsync(int id);

    }
}
