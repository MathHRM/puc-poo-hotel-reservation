using backend.Models;

namespace backend.Repository.IRepository
{
    public interface IRoomRepository
    {
        Task<List<RoomDetailDto>> GetRoomsDetails();
        Task<Room?> GetRoom(int roomNumber);
        Task ReserveRoom(ReservationFormModel reservationData);
    }
}
