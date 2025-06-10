using backend.Models;
using backend.Repository.IRepository;
using backend.Service.IService;

namespace backend.Service
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public async Task<List<RoomDetailDto>> GetRoomsDetails()
        {
            return await _roomRepository.GetRoomsDetails();
        }
    }
}
