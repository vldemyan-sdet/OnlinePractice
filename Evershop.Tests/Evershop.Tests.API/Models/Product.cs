using Newtonsoft.Json;

namespace Evershop.Tests.API.Models
{
    internal class Product
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("product_id")]
        public string ProductId { get; set; }

        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("weight")]
        public string Weight { get; set; }

        [JsonProperty("category_id")]
        public string CategoryId { get; set; }

        [JsonProperty("tax_class")]
        public string TaxClass { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("url_key")]
        public string UrlKey { get; set; }

        [JsonProperty("meta_title")]
        public string MetaTitle { get; set; }

        [JsonProperty("meta_keywords")]
        public string MetaKeywords { get; set; }

        [JsonProperty("meta_description")]
        public string MetaDescription { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("visibility")]
        public string Visibility { get; set; }

        [JsonProperty("manage_stock")]
        public string ManageStock { get; set; }

        [JsonProperty("stock_availability")]
        public string StockAvailability { get; set; }

        [JsonProperty("qty")]
        public string Qty { get; set; }

        [JsonProperty("group_id")]
        public string GroupId { get; set; }

        [JsonProperty("attributes")]
        public Attribute[] Attributes { get; set; }

    }
}
