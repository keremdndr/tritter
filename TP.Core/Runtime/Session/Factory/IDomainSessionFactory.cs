using System;
using System.Collections.Generic;
using System.Text;

namespace TP.Core.Runtime.Session.Factory
{
    public interface IDomainSessionFactory
    {
        IDomainSession Create();
    }
}
