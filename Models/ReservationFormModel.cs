namespace backend.Models
{
    public class ReservationFormModel:Period
    {
        public int UserId { get; set; }
        public int RoomNumber { get; set; }
    }
}
