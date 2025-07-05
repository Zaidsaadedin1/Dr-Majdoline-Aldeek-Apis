using AutoMapper;
using Dr_Majdoline_Aldee.Common.Dtos.AppointmentDtos;
using Dr_Majdoline_Aldee.Common.Dtos.OrderDtos;
using Dr_Majdoline_Aldee.Common.Dtos.Shared;
using Dr_Majdoline_Aldee.Common.Entities;
using Dr_Majdoline_Aldee.Infrastructure;
using Dr_Majdoline_Aldee.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dr_Majdoline_Aldee.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AppointmentService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GenericResponse<IEnumerable<GetAppointmentDto>>> GetAllAppointmentsAsync()
        {
            var appointments = await _context.Appointments.ToListAsync();
            var data = _mapper.Map<IEnumerable<GetAppointmentDto>>(appointments);
            return new GenericResponse<IEnumerable<GetAppointmentDto>>
            {
                Success = true,
                Data = data
            };
        }

        public async Task<GenericResponse<IEnumerable<GetAppointmentDto>>> GetAllUserAppointmentsAsync(string userId)
        {
            var appointments = await _context.Appointments
                .Where(o => o.UserId == userId)
                .ToListAsync();

            var data = _mapper.Map<IEnumerable<GetAppointmentDto>>(appointments);

            return new GenericResponse<IEnumerable<GetAppointmentDto>>
            {
                Success = true,
                Data = data
            };
        }

        public async Task<GenericResponse<GetAppointmentDto>> GetAppointmentByIdAsync(int id)
        {
            var appointment = await _context.Appointments.FirstOrDefaultAsync(o => o.Id == id);
            if (appointment == null)
            {
                return new GenericResponse<GetAppointmentDto>
                {
                    Success = false,
                    Message = "Appointment not found"
                };
            }

            var data = _mapper.Map<GetAppointmentDto>(appointment);
            return new GenericResponse<GetAppointmentDto>
            {
                Success = true,
                Data = data
            };
        }

        public async Task<GenericResponse<int>> CreateAppointmentAsync(CreateAppointmentDto createAppointmentDto)
        {
            var appointment = _mapper.Map<Appointment>(createAppointmentDto);
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();

            return new GenericResponse<int>
            {
                Success = true,
                Data = appointment.Id
            };
        }

        public async Task<GenericResponse<bool>> UpdateAppointmentAsync(int id, UpdateAppointmentDto updateAppointmentDto)
        {
            var appointment = await _context.Appointments.FirstOrDefaultAsync(o => o.Id == id);
            if (appointment == null)
            {
                return new GenericResponse<bool>
                {
                    Success = false,
                    Message = "Appointment not found",
                    Data = false
                };
            }

            _mapper.Map(updateAppointmentDto, appointment);
            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();

            return new GenericResponse<bool>
            {
                Success = true,
                Data = true
            };
        }

        public async Task<GenericResponse<bool>> DeleteAppointmentAsync(int id)
        {
            var appointment = await _context.Appointments.FirstOrDefaultAsync(o => o.Id == id);
            if (appointment == null)
            {
                return new GenericResponse<bool>
                {
                    Success = false,
                    Message = "Appointment not found",
                    Data = false
                };
            }

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();

            return new GenericResponse<bool>
            {
                Success = true,
                Data = true
            };
        }

    }
}
