namespace backend.Models
{
    public class UserReservationDto: Period
    {
        public int RoomReservationId { get; set; }
        public Room Room { get; set; }

    }
}
