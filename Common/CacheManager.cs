using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class CacheManager
    {
        private ApplicationCache cache = new ApplicationCache();
        private const string c_CONNECTION_STR = "CONNECTION_STR";
        private const string c_FACEBOOK_URL = "FACEBOOK_URL";
        private const string c_TWITTER_URL = "TWITTER_URL";
        private const string c_SKYPE_URL = "SKYPE_URL";
        private const string c_SITE_VIDEO_URL = "SITE_VIDEO_URL";
        private const string c_APPLICATION_LOGO_URL = "APPLICATION_LOGO_URL";
        private const string c_ABOUT_DESC = "ABOUT_DESC";
        private const string c_MAIL_ADDRESS = "MAIL_ADDRESS";
        private const string c_CONTACT_NUMBER = "CONTACT_NUMBER";


        private string GetConfigValue(string key)
        {
            string retVal = string.Empty;
            if (!string.IsNullOrEmpty(key))
            {
                retVal = ConfigurationManager.AppSettings[key];
            }
            return retVal;
        }

        public string CONNECTION_STRING
        {
            get
            {
                
                object retObj = cache.GetItem(c_CONNECTION_STR);
                return (retObj != null ? Convert.ToString(retObj) : GetConfigValue(c_CONNECTION_STR));
            }
        }
        public string FACEBOOK_URL
        {
            get
            {
                object retObj = cache.GetItem(c_FACEBOOK_URL);
                return (retObj != null ? Convert.ToString(retObj) : GetConfigValue(c_FACEBOOK_URL));
            }
        }
        public string TWITTER_URL
        {
            get
            {
                object retObj = cache.GetItem(c_TWITTER_URL);
                return (retObj != null ? Convert.ToString(retObj) : GetConfigValue(c_TWITTER_URL));
            }
        }
        public string SKYPE_URL
        {
            get
            {
                object retObj = cache.GetItem(c_SKYPE_URL);
                return (retObj != null ? Convert.ToString(retObj) : GetConfigValue(c_SKYPE_URL));
            }
        }
        public string SITE_VIDEO_URL
        {
            get
            {
                object retObj = cache.GetItem(c_SITE_VIDEO_URL);
                return (retObj != null ? Convert.ToString(retObj) : GetConfigValue(c_SITE_VIDEO_URL));
            }
        }
        public string APPLICATION_LOGO_URL
        {
            get
            {
                object retObj = cache.GetItem(c_APPLICATION_LOGO_URL);
                return (retObj != null ? Convert.ToString(retObj) : GetConfigValue(c_APPLICATION_LOGO_URL));
            }
        }
        public string ABOUT_DESC
        {
            get
            {
                object retObj = cache.GetItem(c_ABOUT_DESC);
                return (retObj != null ? Convert.ToString(retObj) : GetConfigValue(c_ABOUT_DESC));
            }
        }
        public string MAIL_ADDRESS
        {
            get
            {
                object retObj = cache.GetItem(c_MAIL_ADDRESS);
                return (retObj != null ? Convert.ToString(retObj) : GetConfigValue(c_MAIL_ADDRESS));
            }
        }
        public string CONTACT_NUMBER
        {
            get
            {
                object retObj = cache.GetItem(c_CONTACT_NUMBER);
                return (retObj != null ? Convert.ToString(retObj) : GetConfigValue(c_CONTACT_NUMBER));
            }
        }
    }
}
