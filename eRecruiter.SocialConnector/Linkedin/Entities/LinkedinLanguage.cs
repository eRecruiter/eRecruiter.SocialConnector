namespace eRecruiter.SocialConnector.Linkedin.Entities
{
    public class LinkedinLanguage : ILanguage
    {
        public string Id { get; set; }
        public LinkedinName Language { get; set; }
        public LinkedinProficiency Proficiency { get; set; }

        public string Name
        {
            get { return Language.Name; }
        }

        public string Level
        {
            get { return Proficiency != null ? Proficiency.Level : null; }
        }
    }
}