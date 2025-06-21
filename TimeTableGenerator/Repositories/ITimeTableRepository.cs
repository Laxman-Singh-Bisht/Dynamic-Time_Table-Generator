namespace TimeTableGenerator.Repositories
{
    public interface ITimeTableRepository
    {
        List<List<string>> GenerateTimeTable(int workingDays, int SubjectsPerDay, Dictionary<string, int> subjectHours);
    }
}
