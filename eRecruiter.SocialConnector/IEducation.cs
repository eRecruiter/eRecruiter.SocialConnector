

namespace eRecruiter.SocialConnector
{
    public interface IEducation
    {
        string Name { get; }
        string FieldOfStudy { get; }
        string Degree { get; }
        Date StartDate { get; }
        Date EndDate { get; }
        string Notes { get; }
    }
}
