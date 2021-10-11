using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthTranSearch.Web.ViewModels
{
    /// <summary>
    /// the viewmodel to support any possible view validation processes
    /// </summary>
    public class TransactionResultViewModel
    {
        public string BlockHash { get; set; }
        public string BlockNumber { get; set; }
        public string Gas { get; set; }

        public string Hash { get; set; }
        public string From { get; set; }
        public string To { get; set; }

        public string Value { get; set; }

    }
}
