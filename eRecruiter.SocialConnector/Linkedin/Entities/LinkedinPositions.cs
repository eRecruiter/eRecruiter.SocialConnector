using System.Collections.Generic;
using Newtonsoft.Json;

namespace eRecruiter.SocialConnector.Linkedin.Entities
{
    public class LinkedinPositions
    {

        [JsonProperty("_total")]
        public int Total { get; set; }
        public IEnumerable<LinkedinPosition> Values { get; set; }
    }
}
