using DotNetOpenAuth.OAuth.ChannelElements;
using DotNetOpenAuth.OAuth.Messages;
using System;

namespace eRecruiter.SocialConnector
{
    internal class TokenManager : IConsumerTokenManager
    {
        private readonly ITokenManager _tokenManager;

        public TokenManager(ITokenManager tokenManager)
        {
            _tokenManager = tokenManager;
            ConsumerKey = _tokenManager.ConsumerKey;
            ConsumerSecret = _tokenManager.ConsumerSecret;
        }

        public string ConsumerKey { get; private set; }

        public string ConsumerSecret { get; private set; }

        public string GetTokenSecret(string accessToken)
        {
            return _tokenManager.GetTokenSecret(accessToken);
        }

        public void StoreNewRequestToken(UnauthorizedTokenRequest request, ITokenSecretContainingMessage response)
        {
            _tokenManager.StoreTokenSecret(response.Token, response.TokenSecret);
        }

        public void ExpireRequestTokenAndStoreNewAccessToken(string consumerKey, string requestToken, string accessToken, string accessTokenSecret)
        {
            _tokenManager.DeleteTokenSecret(requestToken);
            _tokenManager.StoreTokenSecret(accessToken, accessTokenSecret);
        }

        public TokenType GetTokenType(string token)
        {
            throw new NotImplementedException();
        }
    }
}