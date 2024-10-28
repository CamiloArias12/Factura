
namespace bill_api.Infrastructure.Email
{

    public class SmtpConfig()
    {
        public string Hostname { get; set; } = "localhost";
        public int Port { get; set; } = 25;
    }

}
