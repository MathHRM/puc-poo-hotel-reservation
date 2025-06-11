using Models;
using Microsoft.AspNetCore.Mvc;
using backend.Service.IService;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using backend.Models;

namespace Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRoomService _roomService;

        public HomeController(ILogger<HomeController> logger, IRoomService roomService)
        {
            _logger = logger;
            _roomService = roomService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            List<RoomDetailDto> roomsDetails = await _roomService.GetRoomsDetails();

            return View(roomsDetails);
        }

         public IActionResult Login()
        {
            return View();
        }

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
