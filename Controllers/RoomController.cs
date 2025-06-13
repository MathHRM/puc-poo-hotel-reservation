using backend.Models;
using backend.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Reservation([FromBody] ReservationFormModel reservationData)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _roomService.ReserveRoom(new RoomReservation
            {
                StartDate = reservationData.StartDate,
                EndDate = reservationData.EndDate,
                RoomId = reservationData.RoomNumber,
                UserId = int.Parse(userId)
            });

            return Ok(new { message = "Reserva realizada com sucesso!" });
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPatch]
        [Authorize]
        public async Task<IActionResult> UserReservationUpdate([FromBody] ReservationFormModel reservationData)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _roomService.UpdateUserReservation(
                new RoomReservation
                {
                    StartDate = reservationData.StartDate,
                    EndDate = reservationData.EndDate,
                    RoomId = reservationData.RoomNumber,
                    UserId = int.Parse(userId)
                }
                );

            return Ok(new { message = "Reserva atualizada com sucesso!" });
        }

        [ProducesResponseType(typeof(List<UserReservationDto>), StatusCodes.Status200OK)]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> UserReservations()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(await _roomService.GetUserReservations(int.Parse(userId)));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("Room/DeleteUserReservation/{reservationId}")]
        [HttpDelete("{reservationId}")]
        [Authorize]
        public async Task<IActionResult> DeleteUserReservation([FromRoute] int reservationId)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            await _roomService.DeleteUserReservation(userId, reservationId);

            return Ok();
        }
    }
}
