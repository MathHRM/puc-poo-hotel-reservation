namespace backend.Models
{
    public class ReservationFormModel:Period
    {
        public int RoomNumber { get; set; }
        public int ReservationId { get; set; }
    }
}
