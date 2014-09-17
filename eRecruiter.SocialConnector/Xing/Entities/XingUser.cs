using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using eRecruiter.Utilities;
using System.Linq;

namespace eRecruiter.SocialConnector.Xing.Entities
{
    public class XingUser : IProfile
    {
        public string Id { get; set; }

        [JsonProperty("gender")]
        public string GenderAsString { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("active_email")]
        public string Email { get; set; }

        public Uri PermaLink { get; set; }

        public string Wants { get; set; }

        public string Haves { get; set; }

        [JsonProperty("private_address")]
        public XingAddress PrivateAddress { get; set; }

        [JsonProperty("business_address")]
        public XingAddress BusinessAddress { get; set; }

        [JsonProperty("professional_experience")]
        public XingExperience Experience { get; set; }

        [JsonProperty("educational_background")]
        public XingEducation EducationalBackground { get; set; }

        [JsonProperty("photo_urls")]
        public XingPhotoUrls PhotoUrls { get; set; }

        public IDictionary<string, string> Languages { get; set; }

        [JsonProperty("birth_date")]
        public Date BirthDate { get; set; }

        public Uri Url
        {
            get { return PermaLink; }
        }

        public bool HasUrl
        {
            get { return PermaLink != null; }
        }

        public Gender Gender
        {
            get
            {
                if (GenderAsString.Is("m"))
                    return Gender.Male;
                if (GenderAsString.Is("f"))
                    return Gender.Female;
                return Gender.NotSet;
            }
        }

        public string Address
        {
            get { return string.Format("{0} {1} {2} {3}", PrivateAddress.Street, PrivateAddress.ZipCode, PrivateAddress.City, PrivateAddress.Country); }
        }

        public string PhoneNumber
        {
            get
            {
                if (!PrivateAddress.MobilePhone.IsNoE())
                {
                    return PrivateAddress.MobilePhone;
                }
                if (!PrivateAddress.Phone.IsNoE())
                {
                    return PrivateAddress.Phone;
                }
                return "";
            }
        }
        public string PictureUrl
        {
            get { return PhotoUrls.Large; }
        }

        public IEnumerable<IExperience> Experiences
        {
            get
            {
                var primary = Experience.PrimaryCompany;
                primary.IsCurrent = true;
                var otherExperiences = Experience.NonPrimaryCompanies.ToList();
                otherExperiences.Insert(0, primary);
                return otherExperiences;
            }
        }

        public IEnumerable<IEducation> Education
        {
            get { return EducationalBackground.Schools; }
        }

        public IEnumerable<string> AdditionalEducations
        {
            get { return EducationalBackground.Qualifications; }
        }

        public IEnumerable<ICertification> Certifications
        {
            get { return null; }
        }

        public IEnumerable<string> Skills
        {
            get { return null; }
        }

        IEnumerable<ILanguage> IProfile.Languages
        {
            get
            {
                return
                    Languages.Select(langElement => new Language { Name = langElement.Key, Level = langElement.Value })
                             .Cast<ILanguage>()
                             .ToList();
            }
        }

        IEnumerable<IPublication> IProfile.Publications
        {
            get { return null; }
        }

        public string Summary
        {
            get { return Wants + Environment.NewLine + Haves; }
        }
    }
}
