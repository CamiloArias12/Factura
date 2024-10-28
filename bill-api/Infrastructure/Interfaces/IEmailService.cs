namespace bill_api.Infrastructure.Email.Interfaces
{

    public interface IEmailService

    {
        Task SendEmailAsync(string to, string from, string subject, string body);
    }
}
