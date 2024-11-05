using Newtonsoft.Json;

namespace Evershop.Tests.API.Models
{
    internal class LoginResponseData
    {
        [JsonProperty("data")]
        public BearerId Data { get; set; }

        internal class BearerId
        {
            [JsonProperty("sid")]
            public string Sid { get; set; }
        }
    }
    
}
