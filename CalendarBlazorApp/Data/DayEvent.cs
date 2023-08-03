namespace CalendarBlazorApp.Data
{
    public class DayEvent
    {
        public int DayEventID { get; set; }
        public string? Note { get; set; }
        //public DateTime DateEvent { get; set; } = new DateTime(1900, 1, 1);
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public string DateValue = string.Empty;
        public string DayName = string.Empty;
        public string Message = string.Empty;

        public DayEvent(int dayEventid, string note, DateTime fromDate, DateTime toDate)
        {
            DayEventID = dayEventid;
            Note = note;
            FromDate = fromDate;
            ToDate = toDate;
        }
        public DayEvent()
        {
            
        }
    }
}
