using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using EthTranSearch.Core.Base;

namespace EthTranSearch.Core.Models
{
    public class TransactionAtIndexResponse : BaseResponse
    {
        [JsonPropertyName("result")]
        public TransactionResult Result { get; set; }
    }
}
