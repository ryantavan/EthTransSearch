using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthTranSearch.Domain
{
    public class TransactionQuery
    {
        public long BlockNumber { get; set; }
        public string Address { get; set; }
    }
}
