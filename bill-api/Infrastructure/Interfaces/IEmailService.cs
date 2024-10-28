namespace bill_api.Infrastructure.Email.Interfaces
{

    public interface IEmailService

    {
        Task SendEmail(string to, string from, string subject, string body);
    }
}
