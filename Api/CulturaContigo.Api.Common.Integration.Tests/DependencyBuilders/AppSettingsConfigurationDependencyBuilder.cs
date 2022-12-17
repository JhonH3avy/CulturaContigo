using Microsoft.Extensions.Configuration;

namespace CulturaContigo.Api.Common.Integration.Tests.DependencyBuilders;
internal static class AppSettingsConfigurationDependencyBuilder
{
    public static IConfigurationRoot CreateConfigurationRoot()
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var appSettingsFileName = GetAppSettingsFileName(environment);
        var configurationRoot = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(appSettingsFileName)
            .Build();
        return configurationRoot;
    }

    private static string GetAppSettingsFileName(string? environment)
    {
        return environment switch
        {
            "Development" => "appsettings.Development.json",
            "Staging" => "appsettings.Staging.json",
            "Production" => "appsettings.Production.json",
            _ => "appsettings.Development.json",
        };
    }
}
