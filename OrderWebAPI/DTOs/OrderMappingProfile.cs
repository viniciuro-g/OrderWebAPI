using AutoMapper;
using OrderWebAPI.Models.Entities;

namespace BudgetWebAPI.DTOs
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile() 
        {
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.CustomerName,
                       opt => opt.MapFrom(src => src.Customer.Name)); 

            CreateMap<OrderItem, OrderItemDto>();

            CreateMap<OrderCreateDto, Order>()
                .ForMember(
                    dest=> dest.Description,
                    opt => opt.MapFrom(src => src.Description)
                );
            CreateMap<OrderItemCreateDto, OrderItem>();
            CreateMap<OrderUpdateDto, Order>();
            CreateMap<Order, OrderUpdateDto>();
            CreateMap<OrderItemUpdateDto, OrderItem>();

        }
    }
}
