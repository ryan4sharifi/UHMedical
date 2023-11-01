// DummyEmailSender.cs
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

namespace Medical.Services
{
    public class DummyEmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // This dummy sender does nothing. In a real-world application, you'd send an email here.
            return Task.CompletedTask;
        }
    }
}
