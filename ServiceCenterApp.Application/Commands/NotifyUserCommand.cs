using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceCenterApp.Application.Commands
{
    public class NotifyUserCommand
    {
        public Guid UserId { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
