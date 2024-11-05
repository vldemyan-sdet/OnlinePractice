using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evershop.Tests.API
{
    public abstract class BaseApiTest : BaseTest
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
                //PluginExecutionEngine.AddPlugin(new LogLifecyclePlugin());
                //PluginExecutionEngine.AddPlugin(new ExecutionTimeUnderPlugin());
                //PluginExecutionEngine.AddPlugin(new RetryFailedRequestsWorkflowPlugin());
                //App.AddApiClientExecutionPlugin<ApiBddPlugin>();
                //App.AddAssertionsEventHandler<BDDLoggingAssertExtensions>();
                //ExecutionTimePlugin.Add();
                //APIPluginsConfiguration.AddAssertExtensionsBddLogging();
                //APIPluginsConfiguration.AddRetryFailedRequests();

                _arePluginsAlreadyInitialized = true;
            }
        }
    }
}
