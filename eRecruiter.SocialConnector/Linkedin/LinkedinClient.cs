using System;
using System.Net.Http;

namespace eRecruiter.SocialConnector.Linkedin
{
    public class LinkedinClient : IClient, IDisposable
    {
        public readonly HttpClient _client;

        public LinkedinClient(LinkedinConsumer consumer, string accessToken)
        {
            _client = new HttpClient(consumer.CreateAuthorizingHandler(accessToken, new HttpClientHandler()));

            Users = new LinkedinClientUsersPart(_client);
        }

        public void Dispose()
        {
            _client.Dispose();
        }

        public LinkedinClientUsersPart Users { get; private set; }

        #region IClient interface
        IUsersPart IClient.Users
        {
            get { return Users; }
        }
        #endregion
    }
}
