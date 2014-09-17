namespace eRecruiter.SocialConnector
{
    public interface ITokenManager
    {
        string ConsumerKey { get; }
        string ConsumerSecret { get; }

        string GetTokenSecret(string accessToken);
        void StoreTokenSecret(string accessToken, string accessTokenSecret);
        void DeleteTokenSecret(string accessToken);
    }
}
