namespace CovidTracker.Domain{ 

    public class Cases
    {
        public Stats Total { get; set; }
        public Stats Confirmed { get; set; }
        public Stats Probable { get; set; }
    }

}