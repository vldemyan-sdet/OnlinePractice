using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evershop.Tests.API
{
    internal class Attribute
    {
        [JsonProperty("attribute_code")]
        public string AttributeCode { get; set; }

    }
}
