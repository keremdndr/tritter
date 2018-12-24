using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.IISIntegration;
using TP.Core.Runtime.Session;
using TP.Core.Runtime.Session.Factory;

namespace TP.Web.Core.Runtime.Session.Factory
{
    public sealed class HttpContextBasedDomainSessionFactory : IConcreteDomainSessionFactory
    {
        private readonly IHttpContextAccessor _accessor;

        public HttpContextBasedDomainSessionFactory(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string[] AuthenticationTypes
        {
            get
            {
                return new string[] { IISDefaults.AuthenticationScheme, IISDefaults.Ntlm  };
            }
        }

        public IDomainSession Create()
        {
            return new HttpContextBasedDomainSession(_accessor);
        }
    }
}
