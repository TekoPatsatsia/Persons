using Microsoft.AspNetCore.Mvc;
using Persons.Infrastructure.Interfaces;
using Persons.Models;
using Persons.Infrastructure.Data.Repositories;

namespace Persons.Controllers
{
    [Route("[controller]/[action]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;


        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

         public async Task<IActionResult> Persons()
         {
           var result = await _userService.GetUsersAsync();
           return View(result);
         }
        

        [HttpPost]
        public async Task CreateUserAsync([FromBody] UserPutModel userModel)
        {
            await _userService.CreateUserAsync(userModel);
        }

        [HttpPatch]
        public async Task UpdateUser(int id, UserPutModel model)
        {
            await _userService.UpdateUser(id, model);
        }

        [HttpDelete]
        public async Task DeleteUserAsync(int id)
        {
            await _userService.DeleteUserAsync(id);
        }

    }
}
