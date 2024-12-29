using System.Collections.Generic; 
using System; 
namespace CovidTracker.Domain{ 

    public class Meta
    {
        public DateTime build_time { get; set; }
        public string license { get; set; }
        public string version { get; set; }
        public List<FieldDefinition> field_definitions { get; set; }
        public string data_quality_grade { get; set; }
        public DateTime? updated { get; set; }
        public Tests tests { get; set; }
    }

}