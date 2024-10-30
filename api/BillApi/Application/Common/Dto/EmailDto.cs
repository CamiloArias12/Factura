namespace BillApi.Infrastructure.Email
{
    public class EmailDTO
    {
        public required string To { get; set; } = string.Empty;
        public required string Subject { get; set; } = string.Empty;
        public required string Body { get; set; } = string.Empty;
    }
}