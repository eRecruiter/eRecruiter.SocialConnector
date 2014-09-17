using System.Collections.Generic;

namespace eRecruiter.SocialConnector.Xing.Entities
{
    public class XingEducation
    {
        public IEnumerable<string> Qualifications { get; set; }

        public IEnumerable<XingSchool> Schools { get; set; }
    }
}
