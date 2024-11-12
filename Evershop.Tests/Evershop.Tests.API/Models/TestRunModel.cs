using Newtonsoft.Json;

namespace Evershop.Tests.API.Models
{
    public class TestRunModel
    {
        public string TestName { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Result { get; set; }
    }
}