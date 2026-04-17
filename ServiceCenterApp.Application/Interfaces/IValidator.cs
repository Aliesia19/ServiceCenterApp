using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceCenterApp.Application.Interfaces
{
    public interface IValidator<T>
    {
        void Validate(T command);
    }
}
