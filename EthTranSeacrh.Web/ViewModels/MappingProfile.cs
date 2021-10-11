using AutoMapper;
using EthTranSearch.Domain;

namespace EthTranSearch.Web.ViewModels
{
    /// <summary>
    /// Mapping Profile
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Mapping Profile
        /// </summary>
        public MappingProfile()
        {
            CreateMap<Transaction, TransactionResultViewModel>().ReverseMap();
            CreateMap<TransactionQuery, TransactionQueryViewModel>().ReverseMap();
        }
    }
}
