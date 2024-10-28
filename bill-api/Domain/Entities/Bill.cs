using bill_api.Domain.Common;

namespace bill_api.Domain.Entities
{
    public class Bill : BaseEntity
    {

        public string? ClientId { get; set; }

        public string? InvoiceCode { get; set; }

        public double? InvoiceTotal { get; set; }

        public double? Subtotal { get; set; }

        public double? VAT { get; set; }

        public double? Withholding { get; set; }

        public DateTime CreationDate { get; set; }

        public string? Status { get; set; }

        public string? City { get; set; }

        public bool? IsPaid { get; set; }

        public DateTime? PaymentDate { get; set; }

    }
}
