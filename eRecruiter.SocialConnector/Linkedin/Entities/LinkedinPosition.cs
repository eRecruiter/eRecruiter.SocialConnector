using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace eRecruiter.SocialConnector.Linkedin.Entities
{
    public class LinkedinPosition : IExperience
    {
        public string Id { get; set; }
        public string Title { get; set; }
        [JsonProperty("summary")]
        public string Description { get; set; }
        public LinkedinCompany Company { get; set; }
        public Date StartDate { get; set; }
        public Date EndDate { get; set; }
        public bool IsCurrent { get; set; }

        public string CompanySize { get { return Company.Size; } }
        public string Name { get { return Company.Name; } }
        public string Industry { get { return Company.Industry; } }
    }
}
