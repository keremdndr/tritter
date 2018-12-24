using System;
using System.Collections.Generic;
using System.Text;
using TP.Core.Runtime.Session.Factory;

namespace TP.Core.Runtime.Session.Accessors
{
    public sealed class FactoryDomainSessionAccessor : IDomainSessionAccessor
    {
        private object _sync;

        private readonly IDomainSessionFactory _sessionFactory;

        public FactoryDomainSessionAccessor(IDomainSessionFactory sessionFactory)
        {
            _sync = new object();
            _sessionFactory = sessionFactory;
        }

        private IDomainSession _session;

        public IDomainSession Session
        {
            get
            {
                if (_session == null)
                {
                    lock (_sync)
                    {
                        if (_session == null)
                        {
                            _session = _sessionFactory.Create();
                        }
                    }
                }
                return _session;
            }
        }
    }
}
