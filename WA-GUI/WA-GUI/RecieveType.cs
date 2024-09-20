using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace http_winform
{
    [JsonPolymorphic]
    [JsonDerivedType(typeof(RecievePeopleData), "folder")]
    [JsonDerivedType(typeof(RecieveType), "test")]
    public class RecieveType : BaseForGetData
    {
        [JsonPropertyName("typ")]
        public string Typ { get; set; }
    }
}
