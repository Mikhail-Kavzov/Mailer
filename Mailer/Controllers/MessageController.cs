using Mailer.Models;
using Mailer.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Xml;

namespace Mailer.Controllers
{
    public class MessageController : Controller
    {
        private readonly IMessageRepository _messageRepository;

        public MessageController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public IActionResult Index() => View();

        [NonAction]
        private static MessageMail CreateNewMessage(MessageViewModel model, string? sender)
        {
            MessageMail message = new()
            {
                Sender = sender,
                Receiver = model.Receiver,
                Time = DateTime.Now,
                Title = model.Title,
                Body = model.Body
            };
            return message;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(MessageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var sender = HttpContext.Request.Cookies["Name"];
                _messageRepository.Create(CreateNewMessage(model, sender));
                await _messageRepository.SaveChangesAsync();
                return Content("");
            }
            return View("Index",model);
        }

        [NonAction]
        private static DateTime ConvertFromUTCTime(string Time)
        {
            if (!DateTime.TryParse(Time, out DateTime time))
                throw new ArgumentException("DateTime is not correct");
            return time;
        }

        [HttpPost]
        public async Task<IActionResult> DisplayReceiverMessages(string User, string Time)
        {
            var time = ConvertFromUTCTime(Time);
            var messages = await _messageRepository.GetRangeByReceiverAsync(User, time);
            return PartialView("Message", messages);
        }
    }
}
