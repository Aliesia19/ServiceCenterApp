using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceCenterApp.Application.Commands
{
    public class UpdateServiceCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal BasePrice { get; set; }
    }
}
