using AutoMapper;
using Dr_Majdoline_Aldee.Common.Dtos.OrderDtos;
using Dr_Majdoline_Aldee.Common.Entities;

public class OrderMappingProfile : Profile
{
    public OrderMappingProfile()
    {
        // Mapping from Order entity to GetOrderDto
        CreateMap<Order, GetOrderDto>();

        // Mapping from CreateOrderDto to Order
        CreateMap<CreateOrderDto, Order>();

        // Mapping from UpdateOrderDto to Order
        CreateMap<UpdateOrderDto, Order>();
    }
}
