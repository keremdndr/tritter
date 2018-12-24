using System.Collections.Generic;
using System.Linq;
using TP.Core.Authentication.Providers;

namespace TP.Core.Runtime.Session.Factory
{
    public sealed class AuthTypeBasedSessionFactory : IDomainSessionFactory
    {
        private readonly IEnumerable<IConcreteDomainSessionFactory> _concreteSessionFactories;
        private readonly IDomainSessionFactory _defaultSessionFactory;
        private readonly IAuthenticationTypeProvider _authenticationTypeProvider;

        public AuthTypeBasedSessionFactory(
            IEnumerable<IConcreteDomainSessionFactory> concreteSessionFactories,
            IAuthenticationTypeProvider authenticationTypeProvider,
            IDomainSessionFactory defaultSessionFactory)
        {
            _concreteSessionFactories = concreteSessionFactories;
            _defaultSessionFactory = defaultSessionFactory;
            _authenticationTypeProvider = authenticationTypeProvider;
        }

        public IDomainSession Create()
        {
            //string authenticationType = _authenticationTypeProvider.Provide();
            string authenticationType = "NTLM";

            IDomainSessionFactory sessionFactory = _concreteSessionFactories.FirstOrDefault(r => r.AuthenticationTypes.Any(q => q.Equals(authenticationType))) ?? _defaultSessionFactory;

            IDomainSession session = sessionFactory.Create();

            return session;
        }
    }
}
