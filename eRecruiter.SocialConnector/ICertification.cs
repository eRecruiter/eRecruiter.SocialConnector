
namespace eRecruiter.SocialConnector
{
    public interface ICertification
    {
        string Id { get; }
        string Name { get; }
        string Number { get; }
        string Authority { get; }

        //If only a start date is given there is no expiration date for this certificate
        Date StartDate { get; }
        Date EndDate { get; }
    }
}
