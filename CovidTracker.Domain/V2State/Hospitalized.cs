namespace CovidTracker.Domain{ 

    public class Hospitalized
    {
        public Total Total { get; set; }
        public Stats Currently { get; set; }
        public TotalStats InIcu { get; set; }
        public TotalStats OnVentilator { get; set; }
    }

}