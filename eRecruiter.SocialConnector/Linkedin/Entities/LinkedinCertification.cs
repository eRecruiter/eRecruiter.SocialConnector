using Newtonsoft.Json;

namespace eRecruiter.SocialConnector.Linkedin.Entities
{
    public class LinkedinCertification :ICertification
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public LinkedinName Authority { get; set; }

        string ICertification.Authority { get { return Authority.Name; } }

        //If only a start date is given there is no expiration date for this certificate
        public Date StartDate { get; set; }
        public Date EndDate { get; set; }
    }
}
