using Dr_Majdoline_Aldee.Common.Dtos.AppointmentDtos;
using Dr_Majdoline_Aldee.Common.Dtos.OrderDtos;

namespace Dr_Majdoline_Aldee.Interfaces
{
    public interface IAppointmentService
    {
        Task<IEnumerable<GetAppointmentDto>> GetAllAppointmentsAsync();
        Task<IEnumerable<GetAppointmentDto>> GetAllUserAppointmentsAsync(string userId);
        Task<GetAppointmentDto> GetAppointmentByIdAsync(int id);
        Task<int> CreateAppointmentAsync(CreateAppointmentDto createOrderDto);
        Task<bool> UpdateAppointmentAsync(int id, UpdateAppointmentDto updateOrderDto);
        Task<bool> DeleteAppointmentAsync(int id);
}
    }
