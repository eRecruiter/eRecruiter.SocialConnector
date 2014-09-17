using Newtonsoft.Json;

namespace eRecruiter.SocialConnector.Xing.Entities
{
    public class XingCompany : IExperience
    {
        [JsonProperty("end_date")]
        public string EndDateString { get; set; }
        public string Description { get; set; }
        [JsonProperty("company_size")]
        public string CompanySize { get; set; }
        public string Tag { get; set; }
        public string Title { get; set; }
        [JsonProperty("begin_date")]
        public string BeginDateString { get; set; }
        public string Industry { get; set; }
        public string Url { get; set; }
        [JsonProperty("career_level")]
        public string CareerLevel { get; set; }
        public string Name { get; set; }

        public Date EndDate { get { return XingDateParser.Parse(EndDateString); } }

        public Date StartDate { get { return XingDateParser.Parse(BeginDateString); } }

        public bool IsCurrent { get; set; }
    }
}
