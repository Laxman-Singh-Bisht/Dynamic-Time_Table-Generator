using System.ComponentModel.DataAnnotations;

namespace TimeTableGenerator.Models
{
    public class SubjectHoursModel
    {
        public string SubjectName { get; set; }

        [Range(1,int.MaxValue)]
        public int Hours { get; set; }
    }
}
