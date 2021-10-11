using System.Text.Json.Serialization;
using EthTranSearch.Core.Models;

namespace EthTranSearch.Core.Base
{
    public abstract class BaseRequest :BaseDataModel
    {
        [JsonPropertyName("method")]
        public abstract string Method { get; }

        [JsonPropertyName("params")]
        public abstract object[] Parameters { get; set; }
    }
}
