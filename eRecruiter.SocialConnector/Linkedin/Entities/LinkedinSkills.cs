using System.Collections.Generic;
using Newtonsoft.Json;

namespace eRecruiter.SocialConnector.Linkedin.Entities
{
    public class LinkedinSkills
    {
        [JsonProperty("_total")]
        public int Total { get; set; }

        public IEnumerable<LinkedinSkill> Values { get; set; }
    }
}