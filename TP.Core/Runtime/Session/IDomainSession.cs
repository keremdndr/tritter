namespace TP.Core.Runtime.Session
{
    public interface IDomainSession
    {
        int? UserId { get; }

        string Username { get; }

        string[] Permissions { get; }

        string UserEmail { get; }

        string UserFullName { get; }
    }
}
