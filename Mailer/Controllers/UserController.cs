using Mailer.Models;
using Mailer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mailer.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userRepository.GetNamesAsync();
            return Json(users);
        }
    }
}
