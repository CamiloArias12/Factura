namespace bill_api.Aplication.Common.Dto
{
    public class EmailStatusDto
    {

        public required string Email { get; set; }
        public required string Name { get; set; }
        public required string Status { get; set; }
        public required string BillCode { get; set; }
    }
}

