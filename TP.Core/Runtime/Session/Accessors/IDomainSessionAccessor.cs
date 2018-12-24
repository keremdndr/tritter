using System;
using System.Collections.Generic;
using System.Text;

namespace TP.Core.Runtime.Session.Accessors
{
    public interface IDomainSessionAccessor
    {
        IDomainSession Session { get; }
    }
}
