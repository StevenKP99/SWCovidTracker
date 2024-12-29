using System.Collections.Generic; 
namespace CovidTracker.Domain{ 

    public class FieldDefinition
    {
        public string name { get; set; }
        public string field { get; set; }
        public bool deprecated { get; set; }
        public List<string> prior_names { get; set; }
    }

}