using System;
using System.Collections.Generic;
using System.Text;

namespace Yokogawa.Libraries.Business.Interfaces
{
    public interface ICustomerValidator<T>
    {
        bool Validate(T tObject);
    }
}
