namespace backend.Models
{
    public class Period
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool HasDateConflict(Period? otherPeriod)
        {
            if (otherPeriod == null)
                return false;

            return this.StartDate <= otherPeriod.EndDate &&
                   otherPeriod.StartDate <= this.EndDate;
        }

    }
}
