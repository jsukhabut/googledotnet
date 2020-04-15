using Google.Cloud.SecretManager.V1;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration.SecretsManager
{
    internal class DefaultSecretManager : ISecretManager
    {
        public string GetKey(SecretName secret)
        {
            return secret.SecretId.Replace("--", ConfigurationPath.KeyDelimiter);
        }

        public string Load(SecretPayload secret)
        {
            return secret.Data.ToStringUtf8();
        }
    }
}
