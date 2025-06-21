namespace TimeTableGenerator.Models
{
    public class TimeTableModel
    {
        public int WorkingDay { get; set; }
        public int SubjectPerDay { get; set; }
        public List<string> Subject { get; set; }
    }
}
