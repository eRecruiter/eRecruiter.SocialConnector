using System.Collections.Generic;
using Newtonsoft.Json;

namespace eRecruiter.SocialConnector.Linkedin.Entities
{
    public class LinkedinPublications
    {

        [JsonProperty("_total")]
        public int Total { get; set; }
        public IEnumerable<LinkedinPublication> Values { get; set; }

        public IEnumerable<LinkedinPublication> Publications
        {
            get { return Values; }
        }
    }
}
