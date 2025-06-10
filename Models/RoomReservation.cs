using Models;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class RoomReservation : Period
    {
        [Key]
        public int RoomReservationId { get; set; }
        public User Usuario { get; set; }
        public Room Quarto { get; set; }
  
    }
}
