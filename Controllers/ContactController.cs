using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApi.Models;
using SocialMediaApi.Service;

namespace SocialMediaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly EmailService _emailService;

        public ContactController(AppDbContext context, EmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] ContactMessage message)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.ContactMessages.Add(message);
            await _context.SaveChangesAsync();

            string subject = $"New message from {message.Name}";
            string body = $"Name: {message.Name}\nEmail: {message.Email}\nSubject: {message.Subject}\nMessage:\n{message.Message}";

            await _emailService.SendEmailAsync(subject,body);

            return Ok(new { success = true, message = "Message sent and emailed successfully!" });
        }
    }
}
