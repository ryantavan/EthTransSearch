using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using EthTranSearch.Core.Base;

namespace EthTranSearch.Core.Models
{
    public class TransactionAtIndexRequest : BaseRequest
    {
        public TransactionAtIndexRequest(long blockNumber,long index)
        {
            Id = 0;
            JsonRpcVersion = "2.0";
            Parameters = new string[]
            {
                "0x" + blockNumber.ToString("X"), "0x" + index.ToString("X")
            };
        }

        public override string Method => "eth_getTransactionByBlockNumberAndIndex";
        public override object[] Parameters { get; set; }
    }
}
