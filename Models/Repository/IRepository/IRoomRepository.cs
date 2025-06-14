using backend.Models;

namespace backend.Repository.IRepository
{
    public interface IRoomRepository
    {
        Task<List<RoomDetailDto>> GetRoomsDetails();
        Task<RoomDetailDto?> GetRoomDetail(int roomNumber);
        Task ReserveRoom(RoomReservation reservationData);
        Task<List<RoomDetailDto>> GetUserReservations(int userId);
        Task<RoomReservation?> GetReservation(int reservationId);
        Task DeleteReservation(RoomReservation reservation);
        Task UpdateUserReservation(RoomReservation reservation);

    }
}
