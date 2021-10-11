using System.Collections.Generic;
using System.Threading.Tasks;

namespace EthTranSearch.Domain
{
    public interface IEthService
    {
        Task<IList<Transaction>> FindTransaction(TransactionQuery transactionQuery);
    }
}