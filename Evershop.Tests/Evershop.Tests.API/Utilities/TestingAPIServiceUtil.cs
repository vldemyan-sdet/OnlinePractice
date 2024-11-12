using Evershop.Tests.API.Models;
using Newtonsoft.Json;

namespace Evershop.Tests.API.Utilities
{
    internal class TestingAPIServiceUtil
    {
        public static async Task LogTestExecutionTimeAsync(TestRunModel testRunModel)
        {
            var json = JsonConvert.SerializeObject(testRunModel);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "https://localhost:7180/TestRuns";
            using var client = new HttpClient();

            var response = await client.PostAsync(url, data);
            var body = response.Content.ReadAsStringAsync();
        }
    }
}
