using Microsoft.Extensions.Configuration;

namespace key_vault_console_app
{
    public class SecretAppsettingReader
    {
        public T? ReadSection<T>(string sectionName)
        {
            var environment = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .AddUserSecrets<Program>()
                .AddEnvironmentVariables();

            var configurationRoot = builder.Build();
            return configurationRoot.GetSection(sectionName).Get<T>();
        }
    }
}
