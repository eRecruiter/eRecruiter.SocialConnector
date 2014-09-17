using System.Collections.Generic;
using eRecruiter.SocialConnector.Xing;
using eRecruiter.SocialConnector.Xing.Entities;
using eRecruiter.Utilities;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace eRecruiter.SocialConnector.Samples.Controllers
{
    public class XingController : Controller
    {
        public ActionResult Authorize()
        {
            string accessToken;
            var result = Consumer.ProcessAuthorization(Request, Url.Action("Index"), out accessToken);

            if (accessToken.HasValue())
                AccessToken = accessToken;

            return result;
        }

        public async Task<ActionResult> Index()
        {
            if (AccessToken.IsNoE())
                return RedirectToAction("Authorize");

            using (var client = Consumer.GetClient(AccessToken))
            {
                return View(await client.Users.ForMe());
            }
        }

        public async Task<ActionResult> UnifiedProfile()
        {
            if (AccessToken.IsNoE())
                return RedirectToAction("Authorize");

            using (var client = Consumer.GetClient(AccessToken))
            {
                ViewData.Model = await client.Users.ForMe();
                return View("UnifiedProfile");
            }
        }

        public async Task<ActionResult> FindById(string id)
        {
            if (AccessToken.IsNoE())
                return RedirectToAction("Authorize");

            if (id.IsNoE())
                return View();

            using (var client = Consumer.GetClient(AccessToken))
            {
                return View(await client.Users.ForIds(id));
            }
        }

        private ITokenManager TokenManager
        {
            get { return new SimpleTokenManager(Server.MapPath("~/App_Data/xing_tokens.json"), Settings.Get("XingConsumerKey", ""), Settings.Get("XingConsumerSecret", "")); }
        }

        private XingConsumer Consumer
        {
            get { return new XingConsumer(TokenManager); }
        }

        private string AccessToken
        {
            get
            {
                var cookie = Request.Cookies["xingAccessToken"];
                if (cookie != null && cookie.Value.HasValue())
                    return cookie.Value;
                return null;
            }
            set
            {
                var cookie = new HttpCookie("xingAccessToken", value)
                    {
                        Expires = DateTime.Now.AddMinutes(5)
                    };
                Response.Cookies.Add(cookie);
            }
        }
    }
}
