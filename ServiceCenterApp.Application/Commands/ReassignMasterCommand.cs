using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceCenterApp.Application.Commands
{
    public class ReassignMasterCommand
    {
        public Guid RequestId { get; set; }
        public Guid NewMasterId { get; set; }
    }
}
