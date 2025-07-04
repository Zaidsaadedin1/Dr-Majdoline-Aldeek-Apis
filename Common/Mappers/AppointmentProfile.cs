using AutoMapper;
using Dr_Majdoline_Aldee.Common.Dtos.AppointmentDtos;
using Dr_Majdoline_Aldee.Common.Dtos.OrderDtos;
using Dr_Majdoline_Aldee.Common.Entities;
using Dr_Majdoline_Aldee.Controllers;

public class AppointmentMappingProfile : Profile
{
    public AppointmentMappingProfile()
    {
        // Mapping from Order entity to GetOrderDto
        CreateMap<Appointment, GetAppointmentDto>();

        // Mapping from CreateOrderDto to Order
        CreateMap<CreateAppointmentDto, Appointment>();

        // Mapping from UpdateOrderDto to Order
        CreateMap<UpdateAppointmentDto, Appointment>();
    }
}
