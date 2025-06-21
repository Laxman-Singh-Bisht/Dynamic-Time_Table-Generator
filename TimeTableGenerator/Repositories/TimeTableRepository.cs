namespace TimeTableGenerator.Repositories
{
    public class TimeTableRepository : ITimeTableRepository
    {
        public List<List<string>> GenerateTimeTable(int workingDays, int SubjectsPerDay, Dictionary<string, int> subjectHours)
        { 
            int totalSlots = workingDays * SubjectsPerDay;
            List<string> slots = new List<string>();

            foreach (var subject in subjectHours)
            {
                for (int i = 0; i < subject.Value; i++)
                { 
                    slots.Add(subject.Key);
                }
            }

            var rnd = new Random();
            slots = slots.OrderBy(x => rnd.Next()).ToList();

            List<List<string>> timetable = new();
            for (int i = 0; i < SubjectsPerDay; i++)
            {
                List<string> row = new();
                for (int j = 0; j < workingDays; j++)
                {
                    row.Add(slots[i * workingDays + j]);
                }
                timetable.Add(row); 
            }
            return timetable;
        }
    }
}
