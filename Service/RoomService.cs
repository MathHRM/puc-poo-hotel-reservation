using backend.Models;
using backend.Repository.IRepository;
using backend.Service.IService;
using Models;

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

        public async Task<List<EditableUserReservationModel>> GetEditableUserReservations(int userId)
        {
            return await _roomRepository.GetEditableUserReservations(userId);
        }

        public async Task<List<RoomDetailDto>> GetRoomsDetails()
        {
            return await _roomRepository.GetRoomsDetails();
        }

        public async Task<List<RoomDetailDto>> GetUserReservations(int userId)
        {
            return await _roomRepository.GetUserReservations(userId);
        }

        public async Task ReserveRoom(RoomReservation reservation)  
        {
            await ValidateReservation(reservation);
            await _roomRepository.ReserveRoom(reservation);
        }

        public async Task UpdateUserReservation(RoomReservation reservation)
        {
            await _roomRepository.UpdateUserReservation(reservation);
        }

        private async Task ValidateReservation(RoomReservation newReservation)
        {

            if (newReservation.StartDate > newReservation.EndDate)
                throw new Exception("Data inicio maior que data fim");

            var roomDetail = await _roomRepository.GetRoomDetail(newReservation.RoomId);

            if (roomDetail == null)
                throw new Exception("Quarto para reserva inexistente!");

            if (roomDetail.UnavailablePeriods
                .Any(reservation => Period.CheckDateConflict(reservation, newReservation)))
                throw new Exception("Data de reserva indisponível!");

        }
    }
}
