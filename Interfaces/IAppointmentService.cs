using Dr_Majdoline_Aldee.Common.Dtos.AppointmentDtos;
using Dr_Majdoline_Aldee.Common.Dtos.OrderDtos;
using Dr_Majdoline_Aldee.Common.Dtos.Shared;

namespace Dr_Majdoline_Aldee.Interfaces
{
    public interface IAppointmentService
    {
        Task<GenericResponse<IEnumerable<GetAppointmentDto>>> GetAllAppointmentsAsync();
        Task<GenericResponse<IEnumerable<GetAppointmentDto>>> GetAllUserAppointmentsAsync(string userId);
        Task<GenericResponse<GetAppointmentDto>> GetAppointmentByIdAsync(int id);
        Task<GenericResponse<int>> CreateAppointmentAsync(CreateAppointmentDto createOrderDto);
        Task<GenericResponse<bool>> UpdateAppointmentAsync(int id, UpdateAppointmentDto updateOrderDto);
        Task<GenericResponse<bool>> DeleteAppointmentAsync(int id);
}
    }
