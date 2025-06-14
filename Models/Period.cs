namespace backend.Models
{
    public class Period
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public static bool CheckDateConflict(Period a, Period b) => a.StartDate < b.EndDate && b.StartDate < a.EndDate;

    }
}
