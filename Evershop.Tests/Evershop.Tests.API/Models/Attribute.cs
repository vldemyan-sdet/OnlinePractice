using Newtonsoft.Json;

namespace Evershop.Tests.API.Models
{
    internal class Attribute
    {
        [JsonProperty("attribute_code")]
        public string AttributeCode { get; set; }

    }
}
