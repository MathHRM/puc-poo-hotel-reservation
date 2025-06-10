using Microsoft.AspNetCore.Identity;
using Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // Informa ao EF que este valor não é gerado pelo banco
        public int ApartmentNumber { get; set; }
        public string Description { get; set; }
        public double Rent { get; set; }
        public string ImgURL { get; set; }
        public ICollection<RoomReservation> Reservations { get; set; }
    }

}

