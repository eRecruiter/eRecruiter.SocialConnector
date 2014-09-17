using System.Collections.Generic;
using System.Linq;

namespace eRecruiter.SocialConnector.Linkedin.Entities
{
    public class LinkedinPhoneNumber
    {
        public string PhoneNumber { get; set; }
        public string PhoneType { get; set; } //Possible values are: home, work, mobile
    }
}
