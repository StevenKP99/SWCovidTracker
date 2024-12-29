namespace CovidTracker.Domain; 

public class People
{
    public Stats Total { get; set; }
    public Stats Positive { get; set; }
    public Stats Negative { get; set; }
}