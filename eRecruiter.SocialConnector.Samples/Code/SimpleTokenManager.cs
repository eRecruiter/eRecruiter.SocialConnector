using eRecruiter.Utilities;
using System;
using System.Collections.Generic;
using System.IO;

namespace eRecruiter.SocialConnector.Samples
{
    public class SimpleTokenManager : ITokenManager
    {
        private static Dictionary<string, string> _tokenSecrets = new Dictionary<string, string>();
        private readonly string _pathToFile;

        public SimpleTokenManager(string pathToFile, string consumerKey, string consumerSecret)
        {
            if (pathToFile.IsNoE())
                throw new ArgumentNullException("pathToFile");

            _pathToFile = pathToFile;

            ConsumerKey = consumerKey;
            ConsumerSecret = consumerSecret;
            if (ConsumerKey.IsNoE() || ConsumerSecret.IsNoE())
                throw new ApplicationException("There is either no XING consumer key or XING consumer secret specified in the settings.");

            Load();
        }

        public string ConsumerKey { get; private set; }

        public string ConsumerSecret { get; private set; }

        public string GetTokenSecret(string accessToken)
        {
            return _tokenSecrets[accessToken];
        }

        public void StoreTokenSecret(string accessToken, string accessTokenSecret)
        {
            _tokenSecrets[accessToken] = accessTokenSecret;
            Save();
        }

        public void DeleteTokenSecret(string accessToken)
        {
            _tokenSecrets.Remove(accessToken);
            Save();
        }

        private void Save()
        {
            File.WriteAllText(_pathToFile, Newtonsoft.Json.JsonConvert.SerializeObject(_tokenSecrets));
        }

        private void Load()
        {
            if (File.Exists(_pathToFile))
                _tokenSecrets = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(_pathToFile));
        }
    }
}