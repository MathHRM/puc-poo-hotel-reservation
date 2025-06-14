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
            try
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
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    ErrorMessage = ex.Message
                });
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UserReservationUpdate([FromBody] ReservationFormModel reservationData)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                await _roomService.UpdateUserReservation(
                    new RoomReservation
                    {
                        StartDate = reservationData.StartDate,
                        EndDate = reservationData.EndDate,
                        RoomId = reservationData.RoomNumber,
                        UserId = int.Parse(userId),
                        RoomReservationId = reservationData.ReservationId
                    }
                    );

                return Ok(new { message = "Reserva atualizada com sucesso!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ErrorMessage = ex.Message });
            }
        }

        [ProducesResponseType(typeof(List<RoomDetailDto>), StatusCodes.Status200OK)]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> UserReservations()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                return Ok(await _roomService.GetUserReservations(int.Parse(userId)));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ErrorMessage = ex.Message });
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("Room/DeleteUserReservation/{reservationId}")]
        [HttpDelete("{reservationId}")]
        [Authorize]
        public async Task<IActionResult> DeleteUserReservation([FromRoute] int reservationId)
        {
            try
            {
                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                await _roomService.DeleteUserReservation(userId, reservationId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ErrorMessage = ex.Message });
            }

            return Ok();
        }
    }
}
