using Evershop.Tests.API.Utilities;

namespace Evershop.Tests.API.Plugins;

public class RetryFailedRequestsInfo
{
    public int MaxRetryAttempts { get; set; }
    public int PauseBetweenFailures { get; set; }
    public TimeUnit TimeUnit { get; set; }
}