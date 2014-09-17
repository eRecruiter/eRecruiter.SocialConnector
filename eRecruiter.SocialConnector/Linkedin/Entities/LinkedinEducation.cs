
using System;
using Newtonsoft.Json;

namespace eRecruiter.SocialConnector.Linkedin.Entities
{
    public class LinkedinEducation : IEducation
    {
        public string Id { get; set; }
        [JsonProperty("schoolName")]
        public string Name { get; set; }
        public string FieldOfStudy { get; set; }
        public string Degree { get; set; }
        public string Activities { get; set; }
        public string Notes { get; set; }
        public Date StartDate { get; set; }
        public Date EndDate { get; set; }

        string IEducation.Notes
        {
            get { return Notes + Environment.NewLine + Activities; }
        }
    }
}
