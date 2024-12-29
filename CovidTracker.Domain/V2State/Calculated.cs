namespace CovidTracker.Domain{ 

    public class Calculated
    {
        public double? PopulationPercent { get; set; }
        public int? ChangeFromPriorDay { get; set; }
        public double? SevenDayChangePercent { get; set; }
        public int? SevenDayAverage { get; set; }
    }

}