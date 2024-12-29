namespace CovidTracker.Domain{ 

    public class Outcomes
    {
        public Stats Recovered { get; set; }
        public Hospitalized Hospitalized { get; set; }
        public Death Death { get; set; }
    }

}