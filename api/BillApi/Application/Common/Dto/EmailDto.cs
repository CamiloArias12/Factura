namespace BillApi.Infrastructure.Email
{
    public class EmailDTO
    {
        public required string To { get; set; }
        public required string Subject { get; set; }
        public required string Body { get; set; }
    }
}