namespace backend.Models
{
    public class RoomDetailDto
    {
        public Room Room { get; set; }
      
        public List<Period> UnavailablePeriods { get; set; }
    }
}
