using Newtonsoft.Json;

namespace eRecruiter.SocialConnector.Xing.Entities
{
    public class XingSchool : IEducation
    {
        public string Name { get; set; }
        [JsonProperty("subject")]
        public string FieldOfStudy { get; set; }
        public string Degree { get; set; }
        [JsonProperty("end_date")]
        public string EndDateString { get; set; }
        [JsonProperty("begin_date")]
        public string BeginDateString { get; set; }
        public string Notes { get; set; }

        public Date EndDate { get { return XingDateParser.Parse(EndDateString); } }
        public Date StartDate { get { return XingDateParser.Parse(BeginDateString); } }
    }
}
