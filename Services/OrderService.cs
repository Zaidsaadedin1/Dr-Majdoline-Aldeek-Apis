using AutoMapper;
using Dr_Majdoline_Aldee.Common.Dtos.OrderDtos;
using Dr_Majdoline_Aldee.Common.Entities;
using Dr_Majdoline_Aldee.Infrastructure;
using Dr_Majdoline_Aldee.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dr_Majdoline_Aldee.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public OrderService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetOrderDto>> GetAllOrdersAsync()
        {
            var orders = await _context.Orders.ToListAsync();
            return _mapper.Map<IEnumerable<GetOrderDto>>(orders);
        }

        public async Task<IEnumerable<GetOrderDto>> GetAllUserOrdersAsync(string userId)
        {
            var orders = await _context.Orders
            .Where(o => o.UserId != null && o.UserId == userId)
            .ToListAsync();

            return _mapper.Map<IEnumerable<GetOrderDto>>(orders);
        }

        public async Task<GetOrderDto> GetOrderByIdAsync(int id)
        {
            var order = await _context.Orders
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null) return null;

            return _mapper.Map<GetOrderDto>(order);
        }

        public async Task<int> CreateOrderAsync(CreateOrderDto createOrderDto)
        {
            var order = _mapper.Map<Order>(createOrderDto);
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return order.Id;
        }

        public async Task<bool> UpdateOrderAsync(int id, UpdateOrderDto updateOrderDto)
        {
            var order = await _context.Orders
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null) return false;

            _mapper.Map(updateOrderDto, order); 
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            var order = await _context.Orders
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null) return false;

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
