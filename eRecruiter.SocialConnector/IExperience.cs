using System;

namespace eRecruiter.SocialConnector
{
    public interface IExperience
    {
        string Title { get; }
        string Name { get; }
        string CompanySize { get; }
        string Industry { get; }
        Date StartDate { get; }
        Date EndDate { get; }
        bool IsCurrent { get; }
        string Description { get; }
    }
}
