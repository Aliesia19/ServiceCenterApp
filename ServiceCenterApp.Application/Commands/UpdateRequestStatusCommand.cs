using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceCenterApp.Application.Commands
{
    public class UpdateRequestStatusCommand
    {
        public Guid RequestId { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
