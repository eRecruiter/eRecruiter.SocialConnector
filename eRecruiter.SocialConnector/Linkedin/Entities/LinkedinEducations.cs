using System.Collections.Generic;
using Newtonsoft.Json;

namespace eRecruiter.SocialConnector.Linkedin.Entities
{
    public class LinkedinEducations
    {

        [JsonProperty("_total")]
        public int Total { get; set; }
        public IEnumerable<LinkedinEducation> Values { get; set; }
    }
}
