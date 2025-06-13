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

        public async Task DeleteUserReservation(int userId, int reservationId)
        {
            var reservation = await _roomRepository.GetReservation(reservationId);

            if (reservation == null)
                throw new InvalidOperationException();

            if (reservation.UserId != userId)
                throw new UnauthorizedAccessException();

            await _roomRepository.DeleteReservation(reservation);
            
        }

        public async Task<List<RoomDetailDto>> GetRoomsDetails()
        {
            return await _roomRepository.GetRoomsDetails();
        }

        public async Task<List<RoomReservation>> GetUserReservations(int userId)
        {
            return await _roomRepository.GetUserReservations(userId);
        }

        public async Task ReserveRoom(ReservationFormModel reservationData)
        {
            if (reservationData.StartDate > reservationData.EndDate)
                throw new Exception("Data inicio maior que data fim");

            var room = await _roomRepository.GetRoom(reservationData.RoomNumber);

            if (room == null)
                throw new Exception("Quarto para reserva inexistente!");

            if (room.Reservations != null && room.Reservations.Any(x => x.HasDateConflict(reservationData)))
                throw new Exception("O período solicitado já está reservado por outro hóspede.");

            await _roomRepository.ReserveRoom(reservationData);
        }
    }
}
