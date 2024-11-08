using Evershop.Tests.API.Settings;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Evershop.Tests.API.Plugins
{
    internal class LogLifecyclePlugin : Plugin
    {
        public override void OnBeforeTestInitialize(MethodInfo memberInfo)
        {
            if (ApiSettings.EnableBDDLogging)
            {
                Console.WriteLine($"Start Test {memberInfo.GetType().Name}.{memberInfo.Name}");
            }
        }
    }
}
