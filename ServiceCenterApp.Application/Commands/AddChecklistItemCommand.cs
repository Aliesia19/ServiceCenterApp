using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceCenterApp.Application.Commands
{
    public class AddChecklistItemCommand
    {
        public Guid RequestId { get; set; }
        public Guid ServiceId { get; set; }
        public int Quantity { get; set; }
    }
}
