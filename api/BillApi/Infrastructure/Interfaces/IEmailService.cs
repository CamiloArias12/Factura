namespace BillApi.Infrastructure.Email.Interfaces
{
    public interface IEmailService

    {
        Task<bool> SendEmail(EmailDTO emailDTO);
    }
}
