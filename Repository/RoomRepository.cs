using backend.Models;
using backend.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

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
            catch (DbException)
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
            catch (DbException)
            {
                throw new DatabaseConnectionException();
            }
        }

        public async Task ReserveRoom(RoomReservation reservation)
        {
            try
            {
                await _context.RoomReservations.AddAsync(reservation);
                await _context.SaveChangesAsync();
            }
            catch (DbException)
            {
                throw new DatabaseConnectionException();

            }
        }

        public async Task<List<RoomReservation>> GetUserReservations(int userId)
        {
            try
            {
                return await _context.RoomReservations.Where(x => x.UserId == userId)
                    .Include(x => x.Room)
                    .ToListAsync();
            }
            catch (DbException)
            {
                throw new DatabaseConnectionException();
            }
        }

        public async Task<RoomReservation?> GetReservation(int reservationId)
        {
            try
            {
                return await _context.RoomReservations.Where(x => x.RoomReservationId == reservationId).FirstOrDefaultAsync();
            }
            catch (DbException)
            {
                throw new DatabaseConnectionException();
            }
        }

        public async Task DeleteReservation(RoomReservation reservation)
        {
            try
            {
                _context.RoomReservations.Remove(reservation);
                await _context.SaveChangesAsync();
            }
            catch (DbException)
            {
                throw new DatabaseConnectionException();
            }
        }

        public async Task UpdateUserReservation(RoomReservation reservation)
        {
            try
            {
                var oldReservation = await _context.RoomReservations.FindAsync(reservation.RoomReservationId);

                if (oldReservation == null)
                    throw new KeyNotFoundException();

                oldReservation.StartDate = reservation.StartDate;
                oldReservation.EndDate = reservation.EndDate;
                oldReservation.RoomId = reservation.RoomId;

                await _context.SaveChangesAsync();
            }
            catch (DbException)
            {
                throw new DatabaseConnectionException();
            }
        }
    }
}
