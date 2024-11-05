namespace Evershop.Tests.API
{
    public class App
    {
        private ApiClientAdapter _apiClientService;

        public App()
        {
            _apiClientService = GetApiClientService();
        }

        public ApiClientAdapter ApiClient
        {
            get => _apiClientService;
            init
            {
                _apiClientService = GetApiClientService();
            }
        }

        public bool ShouldReuseRestClient { get; set; } = true;

        //public void AddApiClientExecutionPlugin<TApiClientPlugin>()
        //    where TApiClientPlugin : ApiClientPlugin
        //{
        //    var apiClientPlugin = (TApiClientPlugin)Activator.CreateInstance(typeof(TApiClientPlugin));
        //    apiClientPlugin?.Enable();
        //}

        //public void RemoveApiClientExecutionPlugin<TApiClientPlugin>()
        // where TApiClientPlugin : ApiClientPlugin
        //{
        //    var apiClientPlugin = (TApiClientPlugin)Activator.CreateInstance(typeof(TApiClientPlugin));
        //    apiClientPlugin?.Disable();
        //}

        //public void AddAssertionsEventHandler<TApiAssertionsEventHandler>()
        //    where TApiAssertionsEventHandler : AssertExtensionsEventHandlers
        //{
        //    var elementEventHandler = (TApiAssertionsEventHandler)Activator.CreateInstance(typeof(TApiAssertionsEventHandler));
        //    elementEventHandler?.SubscribeToAll();
        //}

        //public void RemoveAssertionsEventHandler<TApiAssertionsEventHandler>()
        //    where TApiAssertionsEventHandler : AssertExtensionsEventHandlers
        //{
        //    var elementEventHandler = (TApiAssertionsEventHandler)Activator.CreateInstance(typeof(TApiAssertionsEventHandler));
        //    elementEventHandler?.UnsubscribeToAll();
        //}

        public ApiClientAdapter GetApiClientService(string url = null, bool sharedCookies = true, int maxRetryAttempts = 1, int pauseBetweenFailures = 1)
        {
            if (!ShouldReuseRestClient || _apiClientService == null)
            {
                var pauseBetweenFailuresConfig = TimeSpan.FromSeconds(pauseBetweenFailures);

                _apiClientService = new ApiClientAdapter(url ?? "http://localhost:3000/", maxRetryAttempts, pauseBetweenFailuresConfig.Milliseconds);
            }

            return _apiClientService;
        }
    }
}
