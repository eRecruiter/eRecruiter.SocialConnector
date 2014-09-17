
namespace eRecruiter.SocialConnector.Linkedin.Entities
{
    public class LinkedinPublication : IPublication
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public Date Date { get; set; }
        public string Summary { get; set; }
        public string Url { get; set; }
    }
}
