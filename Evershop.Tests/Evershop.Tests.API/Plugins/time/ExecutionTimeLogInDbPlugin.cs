using Evershop.Tests.API.Utilities;
using System.Reflection;

namespace Evershop.Tests.API.Plugins;

public class ExecutionTimeLogInDbPlugin : Plugin
{
    private static readonly Dictionary<string, DateTime> _testsExecutionTimes = new Dictionary<string, DateTime>();

    public override void OnBeforeTestInitialize(MethodInfo memberInfo)
    {
        string testFullName = GetTestFullName(memberInfo);
        DateTime startTime = DateTime.Now;
        if (!_testsExecutionTimes.ContainsKey(testFullName))
        {
            _testsExecutionTimes.Add(testFullName, startTime);
        }
        else
        {
            _testsExecutionTimes[testFullName] = startTime;
        }
    }

    public override void OnAfterTestCleanup(TestOutcome result, MethodInfo memberInfo, Exception failedTestException)
    {
        string testFullName = GetTestFullName(memberInfo);
        DateTime endTime = DateTime.Now;
        if (_testsExecutionTimes.ContainsKey(testFullName))
        {
            var startTime = _testsExecutionTimes[testFullName];
            _testsExecutionTimes.Remove(testFullName);

            var dbUtil = new DbUtil();
            dbUtil.LogTestExecutionTime(testFullName, startTime, endTime, result);
        }

    }

    private string GetTestFullName(MethodInfo memberInfo)
    {
        return $"{memberInfo.DeclaringType.FullName}.{memberInfo.Name}";
    }
}