using System.Text.Json.Serialization;

namespace EthTranSearch.Core.Base
{
    public abstract class BaseDataModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("jsonrpc")]
        public string JsonRpcVersion { get; set; }
    }
}
