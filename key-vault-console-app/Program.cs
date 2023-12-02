// See https://aka.ms/new-console-template for more information
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

Console.WriteLine("Hello, World!");

string keyVaultName = Environment.GetEnvironmentVariable("KEY_VAULT_NAME");
var kvUri = "https://" + keyVaultName + ".vault.azure.net";

var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());

var secretClientId = await client.GetSecretAsync("client-id");
var secretClientSecret = await client.GetSecretAsync("client-secret");

Console.WriteLine($"client-id     = '{secretClientId.Value.Value}'.");
Console.WriteLine($"client-secret = '{secretClientSecret.Value.Value}'.");
