
using System.Net.Mail;
using bill_api.Infrastructure.Email.Interfaces;
namespace bill_api.Infrastructure.Email
{

    public class EmailService(
                           SmtpConfig mailserverOptions) : IEmailService
    {
        private readonly SmtpConfig _mailserverConfiguration = mailserverOptions!;

        public async Task SendEmail(string to, string from, string subject, string body)
        {
            var emailClient = new SmtpClient(_mailserverConfiguration.Hostname, _mailserverConfiguration.Port);

            var message = new MailMessage
            {
                From = new MailAddress(from),
                Subject = subject,
                Body = body
            };
            message.To.Add(new MailAddress(to));
            await emailClient.SendMailAsync(message);
        }
    }
}
