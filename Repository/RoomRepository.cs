using backend.Models;
using backend.Repository.IRepository;
using Microsoft.EntityFrameworkCore;


namespace backend.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly AppDbContext _context;
        public RoomRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Room?> GetRoom(int roomNumber)
        {
            try
            {
                return await _context.Rooms.Where(x => x.RoomNumber == roomNumber).FirstOrDefaultAsync();
            }
            catch
            {
                throw new DatabaseConnectionException();
            }
        }

        public async Task<List<RoomDetailDto>> GetRoomsDetails()
        {
            try
            {
                return await _context.Rooms.Select(room => new RoomDetailDto
                {
                    Room = room,
                    UnavailablePeriods = room.Reservations.Select(reservation => new Period
                    {
                        StartDate = reservation.StartDate,
                        EndDate = reservation.EndDate
                    })
                }).ToListAsync();
            }
            catch
            {
                throw new DatabaseConnectionException();
            }
        }

        public async Task ReserveRoom(ReservationFormModel reservationData)
        {
            var roomReservation = new RoomReservation
            {
                StartDate = reservationData.StartDate,
                EndDate = reservationData.EndDate,
                RoomId = reservationData.RoomNumber,
                UserId = reservationData.UserId
            };
            try
            {
                await _context.RoomReservations.AddAsync(roomReservation);
                _context.SaveChanges();
            }
            catch
            {
                throw new DatabaseConnectionException();

            }

        }

        public async Task<List<RoomReservation>> GetUserReservations(int userId)
        {
            try
            {
                return await _context.RoomReservations.Where(x => x.UserId == userId).ToListAsync();
            }
            catch
            {
                throw new DatabaseConnectionException();
            }
        }

        
    }
}
