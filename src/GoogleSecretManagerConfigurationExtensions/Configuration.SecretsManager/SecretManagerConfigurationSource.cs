using Google.Cloud.SecretManager.V1;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration.SecretsManager
{
    internal class SecretManagerConfigurationSource : IConfigurationSource
    {
        public string ProjectName { get; set; }

        public ISecretManager SecretManager { get; set; }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            var client = SecretManagerServiceClient.Create();
            return new SecretsManagerConfigurationProvider(client, ProjectName, SecretManager);
        }
    }
}
