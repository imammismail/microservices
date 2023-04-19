
using AutoMapper;
using OrderServices.Dtos;
using OrderServices.Models;

namespace OrderServices.Profiles
{
    public class ProductProfiles : Profile
    {
        public ProductProfiles()
        {
            CreateMap<Order, ReadOrderDto>();
            CreateMap<Product, ReadProductDto>();
            CreateMap<Wallet, ReadWalletDto>();
            CreateMap<CreateOrderDto, Order>();
            // CreateMap<UpdateProductDto, Product>();
        }
    }
}