using Mailer.Models;
using Mailer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mailer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserRepository _userRepository;

        public HomeController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                _userRepository.Create(new() { Name = model.Name });
                await _userRepository.SaveChangesAsync();
                return RedirectToAction("Index", "Message", new { Name = model.Name });
            }
            return View(model);
        }
    }
}