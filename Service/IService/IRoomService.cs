using backend.Models;

namespace backend.Service.IService
{
    public interface IRoomService
    {
        Task<List<RoomDetailDto>> GetRoomsDetails();
        Task<List<RoomReservation>> GetUserReservations(int userId);
        Task ReserveRoom(ReservationFormModel reservationData);
    }
}
