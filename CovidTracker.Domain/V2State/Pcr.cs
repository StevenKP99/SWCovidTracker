namespace CovidTracker.Domain{ 

    public class Pcr
    {
        public Stats Total { get; set; }
        public Stats Pending { get; set; }
        public Encounters Encounters { get; set; }
        public Specimens Specimens { get; set; }
        public People People { get; set; }
    }

}