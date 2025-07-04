using Dr_Majdoline_Aldee.Common.Dtos.OrderDtos;

namespace Dr_Majdoline_Aldee.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<GetOrderDto>> GetAllOrdersAsync();
        Task<IEnumerable<GetOrderDto>> GetAllUserOrdersAsync(string userId);
        Task<GetOrderDto> GetOrderByIdAsync(int id);
        Task<int> CreateOrderAsync(CreateOrderDto createOrderDto);
        Task<bool> UpdateOrderAsync(int id, UpdateOrderDto updateOrderDto);
        Task<bool> DeleteOrderAsync(int id);
}
    }
