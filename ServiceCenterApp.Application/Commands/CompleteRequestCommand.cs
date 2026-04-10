using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceCenterApp.Application.Commands
{
    public class CompleteRequestCommand
    {
        public Guid RequestId { get; set; }
    }
}
