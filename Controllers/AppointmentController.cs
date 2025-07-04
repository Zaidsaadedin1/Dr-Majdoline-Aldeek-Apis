using Dr_Majdoline_Aldee.Common.Dtos.AppointmentDtos;
using Dr_Majdoline_Aldee.Common.Dtos.OrderDtos;
using Dr_Majdoline_Aldee.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Dr_Majdoline_Aldee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _orderService;

        public AppointmentController(IAppointmentService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _orderService.GetAllAppointmentsAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await _orderService.GetAppointmentByIdAsync(id);
            if (order == null) return NotFound();
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateAppointmentDto createOrderDto)
        {
            var orderId = await _orderService.CreateAppointmentAsync(createOrderDto);
            return CreatedAtAction(nameof(GetOrder), new { id = orderId }, createOrderDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] UpdateAppointmentDto updateOrderDto)
        {
            var updated = await _orderService.UpdateAppointmentAsync(id, updateOrderDto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var deleted = await _orderService.DeleteAppointmentAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }

        [HttpGet("GetAllUserOrdersAsync/{id}")]
        public async Task<IActionResult> GetAllUserOrdersAsync(string id)

        {
            var userOrders = await _orderService.GetAllUserAppointmentsAsync(id);
            return Ok(userOrders);
        }
    }
}
