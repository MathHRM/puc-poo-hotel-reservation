using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    public class RoomController : ControllerBase
    { 
        [ProducesResponseType(typeof(List<RoomDetailDto>), StatusCodes.Status200OK)]
        public IActionResult GetRooms()
        {
            return Ok();
        }
    }
}
