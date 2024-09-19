using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace http_winform
{
    [JsonPolymorphic]
    [JsonDerivedType(typeof(GetPeopleData), "folder")]
    [JsonDerivedType(typeof(GetTypeData), "test")]
    public class GetTypeData : BaseGetData
    {
        [JsonPropertyName("typ")]
        public string Typ { get; set; }
    }
}
