using Evershop.Tests.API.Utilities;

namespace Evershop.Tests.API.Settings;
public class ApiConfigurationLoader
{
    public static void LoadConfiguration()
    {
        ApiSettings.PauseBetweenFailures = 3;
        ApiSettings.ClientTimeoutSeconds = 15;
        ApiSettings.BaseUrl = "http://localhost:3000/";
        ApiSettings.TimeUnit = TimeUnit.Seconds;
        ApiSettings.MaxRetryAttempts = 3;
        ApiSettings.EnableBDDLogging = true;
        ApiSettings.EnableToastMessages = true;
    }

}
