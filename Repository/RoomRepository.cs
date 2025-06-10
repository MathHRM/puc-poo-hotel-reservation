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
        public async Task<List<RoomDetailDto>> GetRoomsDetails()
        {
            var roomsQuery = _context.Rooms.Select(room => new RoomDetailDto
            {
                Room = room,
                UnavailablePeriods = room.Reservations.Select(reservation => new Period
                {
                    StartDate = reservation.StartDate,
                    EndDate = reservation.EndDate
                })
            });

            return  await roomsQuery.ToListAsync();
        }
    }
}
