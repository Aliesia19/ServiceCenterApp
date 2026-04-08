using System;
using System.Collections.Generic;
using System.Text;

using System;

namespace ServiceCenterApp.Application.Interfaces
{
    public interface IMapper<TDomain, TDto>
    {
        TDto ToDto(TDomain domain);
        TDomain ToDomain(TDto dto);
    }
}