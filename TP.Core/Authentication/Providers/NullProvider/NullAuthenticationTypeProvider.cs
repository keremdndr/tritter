namespace TP.Core.Authentication.Providers.NullProvider
{
    public sealed class NullAuthenticationTypeProvider : IAuthenticationTypeProvider
    {
        public string Provide()
        {
            return null;
        }
    }
}
