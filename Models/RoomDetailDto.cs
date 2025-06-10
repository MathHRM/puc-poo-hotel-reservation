namespace backend.Models
{
    public class RoomDetailDto
    {
        public Room Room { get; set; }
      
        public IEnumerable<Period> UnavailablePeriods { get; set; }
    }
}
