
using AutoMapper;
using WalletServices.Dtos;
using WalletServices.Models;

namespace WalletServices.Profiles
{
    public class WalletProfiles : Profile
    {
        public WalletProfiles()
        {
            CreateMap<Wallet, ReadWalletDto>();
            CreateMap<TopupWalletDto, Wallet>();
            CreateMap<OrderWalletDto, Wallet>();
            // CreateMap<CreateProductDto, Product>();
        }
    }
}