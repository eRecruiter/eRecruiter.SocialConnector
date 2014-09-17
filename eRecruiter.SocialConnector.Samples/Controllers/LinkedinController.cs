using eRecruiter.SocialConnector.Linkedin;
using eRecruiter.Utilities;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace eRecruiter.SocialConnector.Samples.Controllers
{
    public class LinkedinController : Controller
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

        private ITokenManager TokenManager
        {
            get { return new SimpleTokenManager(Server.MapPath("~/App_Data/linkedin_tokens.json"), Settings.Get("LinkedinConsumerKey", ""), Settings.Get("LinkedinConsumerSecret", "")); }
        }

        private LinkedinConsumer Consumer
        {
            get { return new LinkedinConsumer(TokenManager); }
        }

        private string AccessToken
        {
            get
            {
                var cookie = Request.Cookies["linkedinAccessToken"];
                if (cookie != null && cookie.Value.HasValue())
                    return cookie.Value;
                return null;
            }
            set
            {
                var cookie = new HttpCookie("linkedinAccessToken", value)
                    {
                        Expires = DateTime.Now.AddMinutes(5)
                    };
                Response.Cookies.Add(cookie);
            }
        }
    }
}
