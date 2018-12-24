using System;
using System.Collections.Generic;
using System.Text;

namespace TP.Core.Authentication.Providers
{
    public interface IAuthenticationTypeProvider
    {
        string Provide();
    }
}
