
using MailKit.Net.Smtp;
using BillApi.Infrastructure.Email.Interfaces;
using MimeKit;
using MimeKit.Text;
namespace BillApi.Infrastructure.Email
{

    public class EmailService(
                           SmtpConfig mailserverOptions) : IEmailService
    {
        private readonly SmtpConfig _mailserverConfiguration = mailserverOptions!;

        public async Task<bool> SendEmail(EmailDTO emailDTO)
        {

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_mailserverConfiguration.Username));
            email.To.Add(MailboxAddress.Parse(emailDTO.To));
            email.Subject = emailDTO.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = emailDTO.Body };
            try
            {
                var smtp = new SmtpClient();
                await smtp.ConnectAsync(_mailserverConfiguration.Host, _mailserverConfiguration.Port);
                await smtp.AuthenticateAsync(_mailserverConfiguration.Username, _mailserverConfiguration.Password);
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
                return false;
            }
        }
    }
}
