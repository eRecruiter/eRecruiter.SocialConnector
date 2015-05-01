using System;
using System.Web.Mvc;
using System.Net.Http;
using System.Collections.Generic;
using DotNetOpenAuth.Messaging;
using DotNetOpenAuth.OAuth;
using DotNetOpenAuth.OAuth.ChannelElements;
using eRecruiter.Utilities;

namespace eRecruiter.SocialConnector.Linkedin
{
    public class LinkedinConsumer : IConsumer
    {
        private readonly WebConsumer _consumer;

        public LinkedinConsumer(ITokenManager tokenManager)
        {
            _consumer = new WebConsumer(GetServiceProviderDescription(), new TokenManager(tokenManager));
        }

        private ServiceProviderDescription GetServiceProviderDescription()
        {
            return new ServiceProviderDescription
                {
                    RequestTokenEndpoint = new MessageReceivingEndpoint("https://api.linkedin.com/uas/oauth/requestToken", HttpDeliveryMethods.PostRequest),
                    UserAuthorizationEndpoint = new MessageReceivingEndpoint("https://www.linkedin.com/uas/oauth/authorize", HttpDeliveryMethods.PostRequest),
                    AccessTokenEndpoint = new MessageReceivingEndpoint("https://api.linkedin.com/uas/oauth/accessToken", HttpDeliveryMethods.PostRequest),
                    TamperProtectionElements = new ITamperProtectionChannelBindingElement[] {new HmacSha1SigningBindingElement()},ProtocolVersion = ProtocolVersion.V10a
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

            var requestParams = new Dictionary<string, string>();
            requestParams["scope"] = "r_fullprofile r_emailaddress r_contactinfo";
            var request = _consumer.PrepareRequestUserAuthorization(returnUrl, requestParams, null);
            return _consumer.Channel.PrepareResponse(request).AsActionResultMvc5();
        }

        public LinkedinClient GetClient(string accessToken)
        {
            return new LinkedinClient(this, accessToken);
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