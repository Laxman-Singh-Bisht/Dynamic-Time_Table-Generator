using System.ComponentModel.DataAnnotations;

namespace TimeTableGenerator.Models
{
    public class InputModel
    {
        [Range(1, 7)]
        public int WorkingDays { get; set; }

        [Range(1, 8)]
        public int SubjectsPerDay { get; set; }

        [Range(1, int.MaxValue)]
        public int TotalSubjects { get; set; }
        public int TotalHours => WorkingDays * SubjectsPerDay;
    }
}
