using Evershop.Tests.API.Models;
using Evershop.Tests.API.Plugins;
using Newtonsoft.Json;
using RestSharp.Authenticators;
using RestSharp.Serializers.NewtonsoftJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evershop.Tests.API.Utilities
{
    internal class TestingAPIServiceUtil
    {
        public async Task LogTestExecutionTimeAsync(string testName, DateTime startTime, DateTime endTime, TestOutcome testResult)
        {
            var request = new RestRequest("TestRuns", Method.Post);
            var testRunModel = new TestRunModel();
            testRunModel.TestName = testName;
            testRunModel.StartTime = startTime;
            testRunModel.EndTime = endTime;
            testRunModel.Result = testResult.ToString();
            //request.AddJsonBody(new { test_name = testName, start_time = startTime.ToString("o"), end_time = endTime.ToString("o"), result = testResult.ToString() });
            request.AddJsonBody(testRunModel);

            var options = new RestClientOptions()
            {
                ThrowOnAnyError = true,
                FollowRedirects = true,
                MaxRedirects = 10,
                BaseUrl = new Uri("https://localhost:7180/")
            };

            var settings = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var apiClient = new RestClient(options, configureSerialization: s => s.UseNewtonsoftJson(settings));

            var response = await apiClient.PostAsync(request);
        }
    }
}
