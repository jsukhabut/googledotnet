# googledotnet

## Configuration Provider for GCloud Secret Manager

Configuration provider for Microsoft.Extensions.Configuration framework.

See https://cloud.google.com/secret-manager/docs/reference/libraries on how to create application credential file.

Environment variable GOOGLE_APPLICATION_CREDENTIALS must be set.

var project = "mygcloudproject";
builder.AddGoogleSecretManager(project);

```
How to use in AspNetCore.  Add configuration section in Program.cs

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, builder) =>
                {
                    var project = "xxxxxx";
                    builder.AddGoogleSecretManager(project);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
```              
