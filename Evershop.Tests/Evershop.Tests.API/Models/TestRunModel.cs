using Newtonsoft.Json;

namespace Evershop.Tests.API.Models
{
    public class TestRunModel
    {
        [JsonProperty("test_name")]
        public string TestName { get; set; }

        [JsonProperty("start_time")]
        public DateTime StartTime { get; set; }

        [JsonProperty("end_time")]
        public DateTime EndTime { get; set; }

        [JsonProperty("result")]
        public string Result { get; set; }
    }
}