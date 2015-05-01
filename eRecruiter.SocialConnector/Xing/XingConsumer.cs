using System;
using System.Net.Http;
using DotNetOpenAuth.Messaging;
using DotNetOpenAuth.OAuth;
using DotNetOpenAuth.OAuth.ChannelElements;
using eRecruiter.Utilities;
using System.Web;
using System.Web.Mvc;

namespace eRecruiter.SocialConnector.Xing
{
    public class XingConsumer : IConsumer
    {
        private readonly WebConsumer _consumer;

        public XingConsumer(ITokenManager tokenManager)
        {
            _consumer = new WebConsumer(GetServiceProviderDescription(), new TokenManager(tokenManager));
        }

        private ServiceProviderDescription GetServiceProviderDescription()
        {
            return new ServiceProviderDescription
                {
                    RequestTokenEndpoint = new MessageReceivingEndpoint("https://api.xing.com/v1/request_token", HttpDeliveryMethods.PostRequest),
                    UserAuthorizationEndpoint = new MessageReceivingEndpoint("https://api.xing.com/v1/authorize", HttpDeliveryMethods.GetRequest),
                    AccessTokenEndpoint = new MessageReceivingEndpoint("https://api.xing.com/v1/access_token", HttpDeliveryMethods.GetRequest),
                    TamperProtectionElements = new ITamperProtectionChannelBindingElement[] {new HmacSha1SigningBindingElement()}
                };
        }

        public ActionResult ProcessAuthorization(string oauthToken, Uri returnUrl, string redirectOnSuccess, out string accessToken)
        {
            accessToken = null;

            if (oauthToken.HasValue())
            {
                accessToken = _consumer.ProcessUserAuthorization().AccessToken;
                return new RedirectResult(redirectOnSuccess);
            }

            var request = _consumer.PrepareRequestUserAuthorization(returnUrl, null, null);
            return _consumer.Channel.PrepareResponse(request).AsActionResultMvc5();
        }

        public XingClient GetClient(string accessToken)
        {
            return new XingClient(this, accessToken);
        }

        internal DelegatingHandler CreateAuthorizingHandler(string accessToken, HttpMessageHandler innerHandler)
        {
            return _consumer.CreateAuthorizingHandler(accessToken, innerHandler);
        }

        #region IClient interface
        IClient IConsumer.GetClient(string accessToken)
        {
            return GetClient(accessToken);
        }
        #endregion
    }
}