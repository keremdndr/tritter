using TP.Core.Contracts;

namespace TP.Core
{
    public class ConfigurationHelper : IConfigurationHelper
    {
        public static ConfigurationHelper current;

        public ConfigurationHelper()
        {
            current = this;
        }

        public string Environment { get; set; }
        public string ExceptionLessApiKey { get; set; }
    }
}