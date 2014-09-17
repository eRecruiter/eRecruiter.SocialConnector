using Newtonsoft.Json;
using System.Collections.Generic;

namespace eRecruiter.SocialConnector.Xing.Entities
{
    public class XingExperience
    {
        [JsonProperty("primary_company")]
        public XingCompany PrimaryCompany { get; set; }

        [JsonProperty("non_primary_companies")]
        public IEnumerable<XingCompany> NonPrimaryCompanies { get; set; }
    }
}
