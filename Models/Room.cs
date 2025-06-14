using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend.Models
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RoomNumber { get; set; }
        public string Description { get; set; }
        public double Rent { get; set; }
        public string ImgURL { get; set; }
        [JsonIgnore]
        public ICollection<RoomReservation> Reservations { get; set; }
    }

}

