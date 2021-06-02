using System.Text.Json.Serialization;

namespace asp.net_webapi_learning.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass
    {
        Knight,
        Mage,
        Cleric
        
    }
}