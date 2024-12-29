namespace CovidTracker.Application.Models;

public class StateCovidData
{
    public string State { get; set; }
    public int Positive { get; set; }
    public int Negative { get; set; }
    public int HospitalizedCurrently { get; set; }
    public int HospitalizedInIcu { get; set; }
    public int HospitalizedOnVentilator { get; set; }
    public int Total { get; set; }
    public DateTime DataDate { get; set; }
}
