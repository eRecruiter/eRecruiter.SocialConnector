using System;
using System.Collections.Generic;

namespace eRecruiter.SocialConnector
{
    public interface IProfile
    {
        string Id { get; }
        Uri Url { get; }
        bool HasUrl { get; }
        string FirstName { get; }
        string LastName { get; }
        string Email { get; }
        Gender Gender { get; }
        Date BirthDate { get; }
        string Address { get; }
        string PhoneNumber { get; }
        string PictureUrl { get; }
        IEnumerable<IExperience> Experiences { get; }
        IEnumerable<IEducation> Education { get; }
        IEnumerable<string> AdditionalEducations { get; }
        IEnumerable<ICertification> Certifications { get; }
        IEnumerable<string> Skills { get; }
        IEnumerable<ILanguage> Languages { get; }
        IEnumerable<IPublication> Publications { get; }
        string Summary { get; }
    }
}
