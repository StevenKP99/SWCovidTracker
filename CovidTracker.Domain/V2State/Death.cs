namespace CovidTracker.Domain; 

public class Death
{
    public Stats Total { get; set; }
    public Stats Confirmed { get; set; }
    public Stats Probable { get; set; }
}

