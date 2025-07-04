using AutoMapper;
using Dr_Majdoline_Aldee.Common.Dtos.AppointmentDtos;
using Dr_Majdoline_Aldee.Common.Dtos.OrderDtos;
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

        public async Task<IEnumerable<GetAppointmentDto>> GetAllAppointmentsAsync()
        {
            var orders = await _context.Appointments.ToListAsync();
            return _mapper.Map<IEnumerable<GetAppointmentDto>>(orders);
        }

        public async Task<IEnumerable<GetAppointmentDto>> GetAllUserAppointmentsAsync(string userId)
        {
            var orders = await _context.Appointments
            .Where(o => o.UserId != null && o.UserId == userId)
            .ToListAsync();

            return _mapper.Map<IEnumerable<GetAppointmentDto>>(orders);
        }

        public async Task<GetAppointmentDto> GetAppointmentByIdAsync(int id)
        {
            var order = await _context.Appointments
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null) return null;

            return _mapper.Map<GetAppointmentDto>(order);
        }

        public async Task<int> CreateAppointmentAsync(CreateAppointmentDto createOrderDto)
        {
            var appointment = _mapper.Map<Appointment>(createOrderDto);
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();

            return appointment.Id;
        }

        public async Task<bool> UpdateAppointmentAsync(int id, UpdateAppointmentDto updateappointmentDto)
        {
            var order = await _context.Appointments
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null) return false;

            _mapper.Map(updateappointmentDto, order); 
            _context.Appointments.Update(order);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAppointmentAsync(int id)
        {
            var order = await _context.Appointments
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null) return false;

            _context.Appointments.Remove(order);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
