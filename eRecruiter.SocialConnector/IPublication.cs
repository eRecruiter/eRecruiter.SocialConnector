
namespace eRecruiter.SocialConnector
{
    public interface IPublication
    {
        string Id { get; set; }
        string Title { get; set; }
        Date Date { get; set; }
        string Summary { get; set; }
        string Url { get; set; }
    }
}
