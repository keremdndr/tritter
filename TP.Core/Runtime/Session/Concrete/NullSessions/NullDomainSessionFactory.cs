using TP.Core.Runtime.Session.Factory;

namespace TP.Core.Runtime.Session.Concrete.NullSessions
{
    public sealed class NullDomainSessionFactory : IDomainSessionFactory
    {
        public IDomainSession Create()
        {
            return new NullDomainSession();
        }
    }
}
