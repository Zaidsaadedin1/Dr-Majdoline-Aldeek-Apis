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
        public async Task<IActionResult> GetAppointments()
        {
            var orders = await _orderService.GetAllAppointmentsAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointment(int id)
        {
            var order = await _orderService.GetAppointmentByIdAsync(id);
            if (order == null) return NotFound();
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromBody] CreateAppointmentDto createAppointmentDto)
        {
            var orderId = await _orderService.CreateAppointmentAsync(createAppointmentDto);
            return CreatedAtAction(nameof(GetAppointment), new { id = orderId }, createAppointmentDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppointment(int id, [FromBody] UpdateAppointmentDto updateAppointmentDto)
        {
            var updated = await _orderService.UpdateAppointmentAsync(id, updateAppointmentDto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var deleted = await _orderService.DeleteAppointmentAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }

        [HttpGet("GetAllUserAppointmentAsync/{id}")]
        public async Task<IActionResult> GetAllUserAppointmentAsync(string id)

        {
            var userOrders = await _orderService.GetAllUserAppointmentsAsync(id);
            return Ok(userOrders);
        }
    }
}
