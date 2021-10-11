using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EthTranSearch.Web.ViewModels;
using System.Threading;
using AutoMapper;
using EthTranSearch.Domain;

namespace EthTranSearch.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly IEthService _ethService;
        private readonly IMapper _mapper;
        private readonly ILogger<TransactionController> _logger;

        public TransactionController(IEthService ethService, IMapper mapper, ILogger<TransactionController> logger)
        {
            _ethService = ethService;
            _mapper = mapper;
            _logger = logger;
        }

        //[HttpGet]
        //public IEnumerable<TransactionResultViewModel> GetReport(string blockNumber, string address)
        //{
        //    return new List<TransactionResultViewModel>().ToArray();
        //}


        [HttpPost]
        public async Task<IEnumerable<TransactionResultViewModel>> Post(TransactionQueryViewModel queryViewModel)
        {
            var query = _mapper.Map<TransactionQuery>(queryViewModel);
            var transactionResults = await _ethService.FindTransaction(query);
            var transactionResultViewModels = _mapper.Map<List<TransactionResultViewModel>>(transactionResults);

            return transactionResultViewModels.ToArray();
        }
    }
}
