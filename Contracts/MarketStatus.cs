using System.Text.Json.Serialization;

namespace Contracts
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum MarketStatus
    {
        None,
        Canceled,
        Finished,
        Active
    }
}
