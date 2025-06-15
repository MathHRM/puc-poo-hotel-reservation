using backend.Models;
using backend.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Models;
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

        public async Task<RoomDetailDto?> GetRoomDetail(int roomNumber)
        {
            try
            {
                return await _context.Rooms.Where(x => x.RoomNumber == roomNumber)
                    .Select(room => new RoomDetailDto
                    {
                        Room = room,
                        UnavailablePeriods = room.Reservations.Select(reservation => new Period
                        {
                            StartDate = reservation.StartDate,
                            EndDate = reservation.EndDate
                        })
                    }).FirstOrDefaultAsync();
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

        public async Task<List<RoomDetailDto>> GetUserReservations(int userId)
        {
            try
            {
                return await _context.RoomReservations
                    .Where(r => r.UserId == userId)
                    .Select(reservation => new RoomDetailDto
                    {
                        Room = reservation.Room,
                        UnavailablePeriods = reservation.Room.Reservations.Select(r => new Period
                        {
                            StartDate = r.StartDate,
                            EndDate = r.EndDate
                        })
                    }).ToListAsync();
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
                return await _context.RoomReservations
                    .Where(x => x.RoomReservationId == reservationId)
                    .FirstOrDefaultAsync();
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

        public async Task<List<EditableUserReservationModel>> GetEditableUserReservations(int userId)
        {
            try
            {
                return await _context.RoomReservations
                    .Where(r => r.UserId == userId)
                    .Include(r => r.Room)
                        .ThenInclude(room => room.Reservations)
                    .Select(userReservation => new EditableUserReservationModel
                    {
                        UserReservation = userReservation,
                        RoomData = userReservation.Room,
                        ConflictingPeriods = userReservation.Room.Reservations
                            .Where(otherReservation => otherReservation.RoomReservationId != userReservation.RoomReservationId)
                            .Select(conflictingRes => new Period
                            {
                                StartDate = conflictingRes.StartDate,
                                EndDate = conflictingRes.EndDate
                            })
                    }).ToListAsync();
            }
            catch (DbException)
            {
                throw new DatabaseConnectionException();
            }
        }
    }
}
