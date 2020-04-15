using Configuration.SecretsManager;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.Configuration
{
    public static class SecretManagerConfigurationExtensions
    {
        public static IConfigurationBuilder AddGoogleSecretManager(this IConfigurationBuilder configurationBuilder, string projectName, ISecretManager secretManager=null)
        {
            if (configurationBuilder == null)
            {
                throw new ArgumentException(nameof(configurationBuilder));
            }

            if (projectName == null)
            {
                throw new ArgumentException(nameof(projectName));
            }

            configurationBuilder.Add(new SecretManagerConfigurationSource
            {
                ProjectName = projectName,
                SecretManager = secretManager ?? new DefaultSecretManager()
            });

            return configurationBuilder;
        }
    }
}
