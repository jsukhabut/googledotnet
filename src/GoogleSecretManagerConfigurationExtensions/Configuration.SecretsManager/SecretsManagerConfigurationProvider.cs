using Google.Api.Gax.ResourceNames;
using Google.Cloud.SecretManager.V1;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Configuration.SecretsManager
{
    internal class SecretsManagerConfigurationProvider : ConfigurationProvider
    {
        private SecretManagerServiceClient secretManagerServiceClient;
        private string projectName;
        private ISecretManager manager;

        public SecretsManagerConfigurationProvider(SecretManagerServiceClient secretManagerServiceClient, string projectName, ISecretManager manager)
        {
            this.secretManagerServiceClient = secretManagerServiceClient;
            this.projectName = projectName;
            this.manager = manager;
        }
        public override void Load()
        {
            var data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            var request = new ListSecretsRequest
            {
                ParentAsProjectName = ProjectName.FromProject(projectName),
            };

            var secrets = secretManagerServiceClient.ListSecrets(request);
            foreach(var secret in secrets)
            {
                var value = secretManagerServiceClient.AccessSecretVersion($"{secret.Name}/versions/latest");
                string secretVal = this.manager.Load(value.Payload);
                string configKey = this.manager.GetKey(secret.SecretName);
                data.Add(configKey, secretVal);
            }
            Data = data;
        }
    }
}
