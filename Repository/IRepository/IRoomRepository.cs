using backend.Models;

namespace backend.Repository.IRepository
{
    public interface IRoomRepository
    {
        Task<List<RoomDetailDto>> GetRoomsDetails();

    }
}
