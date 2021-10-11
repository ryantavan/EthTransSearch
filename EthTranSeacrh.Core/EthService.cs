using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using EthTranSearch.Core.Models;
using EthTranSearch.Domain;
using Microsoft.Extensions.Configuration;

namespace EthTranSearch.Core
{
    public class EthService: IEthService
    {
        private readonly string _endPointAddress;
        private readonly string _projectId;
        private readonly HttpClient _client; 
        public EthService(IConfiguration configuration)
        {
            _endPointAddress = configuration["EthAccess:Endpoint"];
             _projectId = configuration["EthAccess:ProjectId"];
            _client = new HttpClient();
        }

        /// <summary>
        /// Find the transactions with from address matches the query
        /// </summary>
        /// <param name="transactionQuery"></param>
        /// <returns></returns>
        public async Task<IList<Transaction>> FindTransaction(TransactionQuery transactionQuery)
        {
            //return mocking data for UI design
            //return new List<Transaction>()
            //{
            //    new Transaction()
            //    {
            //        BlockHash = "0x6dbde4b224013c46537231c548bd6ff8e2a2c927c435993d351866d505c523f1",
            //        BlockNumber = "0x8b99c9",
            //        From = "0xd409545096ffe4a4db43875a9b32d766c6364c66",
            //        Gas = "0x5208",
            //        Value = "0xbdd32791b41f000",
            //        Hash = "0xe6d2c63ef9044757338054ed8e938917de97b996815b0c8e30f97fad130101fe",
            //        To = "0x7ef35bb398e0416b81b019fea395219b65c52164"
            //    }
            //};


            var blockTransactions = new List<TransactionResult>();
            List<Transaction> foundTransactions = new List<Transaction>();

            //get blockSize
            int blockSize = await GetBlockSize(transactionQuery.BlockNumber);
            if (blockSize > 0)
            {
                for (int i = 0; i < blockSize; i++)
                {
                    var result = GetTransactionAtIndex(transactionQuery.BlockNumber, i);
                    blockTransactions.Add(result.Result);
                }

                // I assume Gas, BlockNumber and Value are not exceeding the int32, got to learn more these values
                foundTransactions = blockTransactions.Where(x => x.From == transactionQuery.Address).Select(t =>
                    new Transaction()
                    {
                        BlockHash = t.BlockHash,
                        BlockNumber = t.BlockNumber,
                        From = t.From,
                        Gas = t.Gas,
                        Hash = t.Hash,
                        To = t.To,
                        Value = t.Value
                    }).ToList();

                return foundTransactions;
            }
            else
            {
                return foundTransactions;
            }
        }

        public async Task<int> GetBlockSize(long blockNumber)
        {
            var req = new BlockSizeRequest(blockNumber);
            var response = await _client.PostAsJsonAsync($"{_endPointAddress}{_projectId}", req);
            if (response.IsSuccessStatusCode)
            {
                var sizeObj = await response.Content.ReadFromJsonAsync<BlockSizeResponse>();
                return sizeObj != null ? Convert.ToInt32(sizeObj.result, 16) : 0;
            }
            else
            {
                //TODO: log the reason if there is any
                return 0;
            }
        }

        private async Task<TransactionResult> GetTransactionAtIndex(long blockNumber, long index)
        {
            var req = new TransactionAtIndexRequest(blockNumber,index);
            var response = await _client.PostAsJsonAsync($"{_endPointAddress}{_projectId}", req);
            if (response.IsSuccessStatusCode)
            {
                var transactionResult = await response.Content.ReadFromJsonAsync<TransactionAtIndexResponse>();
                if (transactionResult != null)
                {
                    return transactionResult.Result;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
