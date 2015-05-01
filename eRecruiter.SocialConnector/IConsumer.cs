using System;
using System.Web;
using System.Web.Mvc;

namespace eRecruiter.SocialConnector
{
    public interface IConsumer
    {
        ActionResult ProcessAuthorization(string oauthToken, Uri returnUrl, string redirectOnSuccess, out string accessToken);
        IClient GetClient(string accessToken);
    }
}
