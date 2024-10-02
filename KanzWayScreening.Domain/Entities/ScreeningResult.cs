namespace KanzWayScreening.Domain.Entities;

public class ScreeningResult : BaseEntity
{
    public List<string> Results { get; private set; }

    public ScreeningResult()
    {
        Results = new List<string>();
    }

    public void AddResult(string result)
    {
        Results.Add(result);
    }
}
