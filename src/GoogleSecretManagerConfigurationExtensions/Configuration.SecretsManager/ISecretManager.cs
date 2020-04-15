using Google.Cloud.SecretManager.V1;
using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration.SecretsManager
{
    public interface ISecretManager
    {
        string Load(SecretPayload secret);
        string GetKey(SecretName secret);
    }
}
