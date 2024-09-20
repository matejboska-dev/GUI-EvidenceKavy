using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace http_winform
{
    internal class SendData
    {
        [JsonPropertyName("user")]
        public string User { get; set; }

        [JsonPropertyName("type[]")]
        public int[] TypeArray { get; set; }
    }
}
