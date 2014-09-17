using Newtonsoft.Json;

namespace eRecruiter.SocialConnector.Xing.Entities
{
    public class XingPhotoUrls
    {
        public string Large { get; set; }
        public string Thumb { get; set; }
        [JsonProperty("mini_thumb")]
        public string MiniThumb { get; set; }
        [JsonProperty("medium_thumb")]
        public string MediumThumb { get; set; }
        [JsonProperty("maxi_thumb")]
        public string MaxiThumb { get; set; }
    }
}
