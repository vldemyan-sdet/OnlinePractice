
namespace Evershop.Tests.API.Assertions
{
    public class BDDLoggingAssertExtensions : AssertExtensionsEventHandlers
    {
        public override void SubscribeToAll()
        {
            if (ApiSettings.EnableBDDLogging)
            {
                base.SubscribeToAll();
            }
        }

        public override void UnsubscribeToAll()
        {
            if (ApiSettings.EnableBDDLogging)
            {
                base.UnsubscribeToAll();
            }
        }

        protected override void AssertStatusCodeEventHandler(object sender, ApiAssertEventArgs arg)
        {
            Console.WriteLine($"Assert response status code is equal to {arg.ActionValue}.");
        }
    }
    
}
