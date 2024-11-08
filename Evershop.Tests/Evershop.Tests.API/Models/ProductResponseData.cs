using Newtonsoft.Json;

namespace Evershop.Tests.API.Models
{
    internal class ProductResponseData
    {
        [JsonProperty("data")]
        public ProductData Data { get; set; }
        internal class ProductData
        {
            [JsonProperty("uuid")]
            public string Uuid { get; set; }
            [JsonProperty("product_description_id")]
            public string ProductDescriptionId { get; set; }
        }
    }
}
