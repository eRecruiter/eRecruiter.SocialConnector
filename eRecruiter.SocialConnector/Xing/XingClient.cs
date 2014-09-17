using System;
using System.Net.Http;

namespace eRecruiter.SocialConnector.Xing
{
    public class XingClient : IClient, IDisposable
    {
        private readonly HttpClient _client;

        public XingClient(XingConsumer consumer, string accessToken)
        {
            _client = new HttpClient(consumer.CreateAuthorizingHandler(accessToken, new HttpClientHandler()));
            Users = new XingClientUsersPart(_client);
        }

        public void Dispose()
        {
            _client.Dispose();
        }

        public XingClientUsersPart Users { get; private set; }

        #region IClient interface
        IUsersPart IClient.Users
        {
            get { return Users; }
        }
        #endregion
    }
}
