using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthTranSearch.Web.ViewModels
{
    public class TransactionQueryViewModel
    {
        public int BlockNumber { get; set; }
        public string Address { get; set; }
    }
}
