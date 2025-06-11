using backend.Models;
using backend.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{

    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [ProducesResponseType(typeof(List<RoomDetailDto>), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> GetRoomsDetails()
        {
            return Ok(await _roomService.GetRoomsDetails());
        }

        [ProducesResponseType( StatusCodes.Status200OK)]
        [HttpPost]
        public async Task<IActionResult> Reservation([FromBody] ReservationFormModel reservationData)
        {
            await _roomService.ReserveRoom(reservationData);
            return Ok();
        }
    }
}
