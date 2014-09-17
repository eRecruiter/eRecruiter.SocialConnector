using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace eRecruiter.SocialConnector.Linkedin.Entities
{
    public class LinkedinPerson : IProfile
    {
        [OnDeserialized]
        public void OnDeserialized(StreamingContext context)
        {
            BirthDate = BirthDate ?? new Date();
            PhoneNumbers = PhoneNumbers ?? new LinkedinPhoneNumbers();
            PhoneNumbers.Values = PhoneNumbers.Values ?? Enumerable.Empty<LinkedinPhoneNumber>();
            Courses = Courses ?? new LinkedinCourses();
            Courses.Values = Courses.Values ?? Enumerable.Empty<LinkedinCourse>();
            Certifications = Certifications ?? new LinkedinCertifications();
            Certifications.Values = Certifications.Values ?? Enumerable.Empty<LinkedinCertification>();
            Publications = Publications ?? new LinkedinPublications();
            Publications.Values = Publications.Values ?? Enumerable.Empty<LinkedinPublication>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        [JsonProperty("DateOfBirth", DefaultValueHandling = DefaultValueHandling.Populate)]
        public Date BirthDate { get; set; }
        public string PublicProfileUrl { get; set; }
        public string PictureUrl { get; set; }
        public string Id { get; set; }
        public string EmailAddress { get; set; }
        public string MainAddress { get; set; }
        public string Summary { get; set; }
        public LinkedinPhoneNumbers PhoneNumbers { get; set; }
        public LinkedinPublications Publications { get; set; }
        public LinkedinLanguages Languages { get; set; }
        public LinkedinSkills Skills { get; set; }
        public LinkedinCertifications Certifications { get; set; }
        public LinkedinEducations Educations { get; set; }
        public LinkedinCourses Courses { get; set; }
        public LinkedinPositions Positions { get; set; }

        public Uri Url
        {
            get { return PublicProfileUrl != null ? new Uri(PublicProfileUrl) : new Uri(" http://www.linkedin.com/profile/view?id=" + Id); }
        }

        public bool HasUrl
        {
            get { return !string.IsNullOrWhiteSpace(PublicProfileUrl); }
        }

        public string Email
        {
            get { return EmailAddress; }
        }

        public Gender Gender
        {
            get { return Gender.NotSet; }
        }

        public string Address
        {
            get { return MainAddress; }
        }

        public string PhoneNumber
        {
            get
            {
                if (PhoneNumbers.Values == null)
                    return "";

                var linkedinPhoneNumbers = PhoneNumbers.Values as LinkedinPhoneNumber[] ?? PhoneNumbers.Values.ToArray();

                if (linkedinPhoneNumbers.Any(x => x.PhoneType == "mobile"))
                    return linkedinPhoneNumbers.First(x => x.PhoneType == "mobile").PhoneNumber;
                if (linkedinPhoneNumbers.Any(x => x.PhoneType == "home"))
                    return linkedinPhoneNumbers.First(x => x.PhoneType == "home").PhoneNumber;
                if (linkedinPhoneNumbers.Any(x => x.PhoneType == "work"))
                    return linkedinPhoneNumbers.First(x => x.PhoneType == "work").PhoneNumber;
                return "";
            }
        }

        string IProfile.PictureUrl
        {
            get { return PictureUrl; }
        }

        public IEnumerable<IExperience> Experiences
        {
            get { return Positions.Values; }
        }

        public IEnumerable<IEducation> Education
        {
            get { return Educations.Values; }
        }

        public IEnumerable<string> AdditionalEducations
        {
            get { return Courses.Values.Select(x => x.Name).ToList(); }
        }

        IEnumerable<string> IProfile.Skills
        {
            get {
                if (Skills == null || Skills.Values == null)
                {
                    return Enumerable.Empty<string>();
                }
                return Skills.Values.Select(x => x.Skill.Name).ToList();
            }
        }

        IEnumerable<ICertification> IProfile.Certifications
        {
            get { return Certifications.Values; }
        }

        IEnumerable<ILanguage> IProfile.Languages
        {
            get { return Languages == null ? new List<ILanguage>().AsEnumerable() : Languages.Values; }
        }

        IEnumerable<IPublication> IProfile.Publications
        {
            get { return Publications.Values; }
        }
    }
}
