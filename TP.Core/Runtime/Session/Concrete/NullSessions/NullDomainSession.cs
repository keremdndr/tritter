namespace TP.Core.Runtime.Session.Concrete.NullSessions
{
    public sealed class NullDomainSession : IDomainSession
    {
        public int? UserId
        {
            get
            {
                return null;
            }
        }

        public string Username
        {
            get
            {
                return null;
            }
        }

        public string[] Permissions
        {
            get
            {
                return null;
            }
        }

        public string UserEmail
        {
            get
            {
                return null;
            }
        }

        public string UserFullName
        {
            get
            {
                return null;
            }
        }
    }
}
