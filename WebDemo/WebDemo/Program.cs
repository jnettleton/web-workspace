//#define ENABLE_USER_SECRETS

using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using WebDemo;

internal class Program
{
    public static void Main(string[] args)
    {
        // NOTE: need to set up Azure account for local development
        // https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication/local-development-dev-accounts

#if ENABLE_USER_SECRETS
        // NOTE: use "Manage User Secrets" to store secrets
        var secretAppsettingReader = new SecretAppsettingReader();
        var secretValues = secretAppsettingReader.ReadSection<SecretValues>("KeyVault");
#endif

        var vaultName = "web-demo-kv";
        var vaultUrl = "https://" + vaultName + ".vault.azure.net";

        // Create a new secret client using the default credential from Azure.Identity using environment variables previously set,
        // including AZURE_CLIENT_ID, AZURE_CLIENT_SECRET, and AZURE_TENANT_ID.
        var client = new SecretClient(vaultUri: new Uri(vaultUrl), credential: new DefaultAzureCredential());

        // Retrieve a secret using the secret client.
        var secretClientId = client.GetSecret("client-id");
        var secretClientSecret = client.GetSecret("client-secret");

    }
}

#if ENABLE_USER_SECRETS
public class SecretValues
{
    public string TenantId { get; set; }
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
}
#endif
