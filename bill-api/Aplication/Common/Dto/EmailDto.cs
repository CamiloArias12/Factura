using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bill_api.Infrastructure.Email
{
    public class EmailDTO
    {
        public required string To { get; set; } = string.Empty;
        public required string Subject { get; set; } = string.Empty;
        public required string Body { get; set; } = string.Empty;
    }
}