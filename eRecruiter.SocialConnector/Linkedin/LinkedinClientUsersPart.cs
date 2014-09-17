using System.Collections.Generic;
using eRecruiter.SocialConnector.Linkedin.Entities;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;

namespace eRecruiter.SocialConnector.Linkedin
{
    public class LinkedinClientUsersPart : IUsersPart
    {
        private readonly HttpClient _client;

        //All Properties which needed to get the desired data. If list is null the Key is a main key.
        private readonly Dictionary<string, IEnumerable<string>> _apiProperties = new Dictionary<string, IEnumerable<string>>
                {
                    {"id", null},
                    {"first-name", null},
                    {"last-name", null},
                    {"date-of-birth", null},
                    {"main-address", null},
                    {"email-address", null},
                    {"phone-numbers", new[] {"phone-type", "phone-number"}}, 
                    {"summary", null},
                    {"public-profile-url", null},
                    {"positions", new[] {"id", "title", "summary", "start-date", "end-date", "is-current", "company"}},
                    {"picture-url", null},
                    {"publications", new[] {"id", "title", "date", "url", "summary"}},
                    {"languages",new[] {"id", "language", "proficiency"}},
                    {"Skills", new[] {"id", "skill"}},
                    {"certifications", new[] {"id", "name", "authority", "number", "start-date", "end-date"}},
                    {"educations", new[] {"id", "school-name", "field-of-study", "start-date", "end-date", "degree", "activities", "notes" }},
                    {"courses", new[] {"id", "name", "number"}}
                };

        public LinkedinClientUsersPart(HttpClient client)
        {
            _client = client;
        }

        public async Task<LinkedinPerson> ForMe()
        {

            var properties = _apiProperties.Aggregate("", (current, prop) => current + (prop.Key + (prop.Value != null ? ":(" + prop.Value.Aggregate((a, b) => a + "," + b) + ")" : "")) + ",").TrimEnd(',');
            var response = await _client.GetAsync("http://api.linkedin.com/v1/people/~:(" + properties + ")?format=json");
            //var response = await _client.GetAsync("http://api.linkedin.com/v1/people/~:(id,first-name,last-name,email-address,public-profile-url,picture-url,publications:(id,title,publisher,authors,date,url,summary))?format=json");

            var content = await response.Content.ReadAsStringAsync();
            var person = await response.Content.ReadAsAsync<LinkedinPerson>();
            return person;
        }

        #region IUsersPart interface
        async Task<IProfile> IUsersPart.ForMe()
        {
            return await ForMe();
        }
        #endregion
    }

    
}
