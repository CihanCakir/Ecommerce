using API.Dtos;
using API.Dtos.Accout;
using API.Dtos.Customer;
using AutoMapper;
using Core.Entities;
using Core.Entities.Customer;
using Core.Entities.Identity;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>()
                            .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                            .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                            .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<CustomerBasketDto, CustomerBasket>().ReverseMap();
            CreateMap<BasketItemDto, BasketItem>().ReverseMap();
            CreateMap<AddressDto, Core.Entities.OrderAggregate.Address>();
        }
    }
}