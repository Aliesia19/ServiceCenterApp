using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceCenterApp.Application.Commands
{
    public class RejectRequestCommand
    {
        public Guid RequestId { get; set; }
        public string Reason { get; set; } = string.Empty;
    }
}
