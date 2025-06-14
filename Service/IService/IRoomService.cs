using backend.Models;

namespace backend.Service.IService
{
    public interface IRoomService
    {
        Task<List<RoomDetailDto>> GetRoomsDetails();
        Task<List<RoomDetailDto>> GetUserReservations(int userId);
        Task DeleteUserReservation(int userId, int reservationId);
        Task ReserveRoom(RoomReservation reservation);
        Task UpdateUserReservation(RoomReservation reservation);
    }
}
