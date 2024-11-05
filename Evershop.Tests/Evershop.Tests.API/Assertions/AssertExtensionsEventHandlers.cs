using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evershop.Tests.API.Assertions
{
    public abstract class AssertExtensionsEventHandlers
    {
        public virtual void SubscribeToAll()
        {
            ApiAssertExtensions.AssertStatusCodeEvent += AssertStatusCodeEventHandler;
            ApiAssertExtensions.AssertSuccessStatusCodeEvent += AssertSuccessStatusCodeEventHandler;
        }

        public virtual void UnsubscribeToAll()
        {
            ApiAssertExtensions.AssertStatusCodeEvent -= AssertStatusCodeEventHandler;
            ApiAssertExtensions.AssertSuccessStatusCodeEvent -= AssertSuccessStatusCodeEventHandler;
        }

        protected virtual void AssertStatusCodeEventHandler(object sender, ApiAssertEventArgs arg)
        {
        }

        protected virtual void AssertSuccessStatusCodeEventHandler(object sender, ApiAssertEventArgs arg)
        {
        }

    }
}
