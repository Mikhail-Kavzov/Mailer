using Mailer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mailer.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid) //add userName
            {
                HttpContext.Response.Cookies.Append("Name", model.Name);
                return RedirectToAction("Index", "Message");
            }
            return View(model);
        }
    }
}