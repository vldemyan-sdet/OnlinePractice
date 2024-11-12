using Evershop.Tests.API.Assertions;
using Evershop.Tests.API.Plugins;

namespace Evershop.Tests.API
{
    public abstract class APITest : BaseTest
    {
        private static bool _arePluginsAlreadyInitialized;

        public App App => new App();

        protected override void ClassCleanup()
        {
            App.ApiClient.Dispose();
        }

        protected override void Configure()
        {
            if (!_arePluginsAlreadyInitialized)
            {
                PluginExecutionEngine.AddPlugin(new LogLifecyclePlugin());
                PluginExecutionEngine.AddPlugin(new ExecutionTimeUnderPlugin());
                PluginExecutionEngine.AddPlugin(new ExecutionTimeLogInDbPlugin());
                PluginExecutionEngine.AddPlugin(new RetryFailedRequestsWorkflowPlugin());
                App.AddApiClientExecutionPlugin<ApiBddPlugin>();
                App.AddAssertionsEventHandler<BDDLoggingAssertExtensions>();
                //ExecutionTimePlugin.Add();
                //APIPluginsConfiguration.AddAssertExtensionsBddLogging();
                //APIPluginsConfiguration.AddRetryFailedRequests();

                _arePluginsAlreadyInitialized = true;
            }
        }
    }
}
