using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceCenterApp.Application.Commands
{
    public class SendMessageCommand
    {
        public Guid RequestId { get; set; }
        public Guid SenderId { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
