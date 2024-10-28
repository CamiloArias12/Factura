using bill_api.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace bill_api.Domain.Entities
{
    public class Client : BaseEntity
    {
        public required string Name { get; set; }

        [EmailAddress]
        public required string Email { get; set; }

    }
}
