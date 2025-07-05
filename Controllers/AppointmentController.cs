using Dr_Majdoline_Aldee.Common.Dtos.AppointmentDtos;
using Dr_Majdoline_Aldee.Common.Dtos.OrderDtos;
using Dr_Majdoline_Aldee.Common.Dtos.Shared;
using Dr_Majdoline_Aldee.Common.Dtos.UserDto;
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
        public async Task<ActionResult<GenericResponse<IEnumerable<GetAppointmentDto>>>> GetAppointments()
        {
            var response = await _orderService.GetAllAppointmentsAsync();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GenericResponse<GetAppointmentDto>>> GetAppointment(int id)
        {
            var response = await _orderService.GetAppointmentByIdAsync(id);
            if (!response.Success)
                return NotFound(response);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<GenericResponse<int>>> CreateAppointment([FromBody] CreateAppointmentDto createAppointmentDto)
        {
            var response = await _orderService.CreateAppointmentAsync(createAppointmentDto);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAppointment(int id, [FromBody] UpdateAppointmentDto updateAppointmentDto)
        {
            var response = await _orderService.UpdateAppointmentAsync(id, updateAppointmentDto);
            if (!response.Success)
                return NotFound(response);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAppointment(int id)
        {
            var response = await _orderService.DeleteAppointmentAsync(id);
            if (!response.Success)
                return NotFound(response);
            return NoContent();
        }

        [HttpGet("GetAllUserAppointmentAsync/{id}")]
        public async Task<ActionResult<GenericResponse<IEnumerable<GetAppointmentDto>>>> GetAllUserAppointmentAsync(string id)
        {
            var response = await _orderService.GetAllUserAppointmentsAsync(id);
            return Ok(response);
        }

    }
}
