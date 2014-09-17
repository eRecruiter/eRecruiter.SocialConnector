using Newtonsoft.Json;

namespace eRecruiter.SocialConnector.Xing.Entities
{
    public class XingAddress
    {
        [JsonProperty("zip_code")]
        public string ZipCode { get; set; }
        [JsonProperty("mobile_phone")]
        public string MobilePhone { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
    }
}
