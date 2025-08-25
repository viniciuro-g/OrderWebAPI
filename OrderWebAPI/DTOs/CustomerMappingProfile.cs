using AutoMapper;
using OrderWebAPI.Models.Entities;

namespace BudgetWebAPI.DTOs
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerCreateDto, Customer>();
            CreateMap<CustomerUpdateDto, Customer>();
        }

    }
}
