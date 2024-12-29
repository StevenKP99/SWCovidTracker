namespace CovidTracker.Domain{ 

    public class Data
    {
        public DateTime Date { get; set; }
        public string State { get; set; }
        public Meta Meta { get; set; }
        public Cases Cases { get; set; }
        public Tests Tests { get; set; }
        public Outcomes Outcomes { get; set; }
    }

}