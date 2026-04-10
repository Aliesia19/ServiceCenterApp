using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceCenterApp.Application.Commands
{
    public class AssignMasterCommand
    {
        public Guid RequestId { get; set; }
        public Guid MasterId { get; set; }
    }
}
