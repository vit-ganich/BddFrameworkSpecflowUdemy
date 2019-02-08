using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BddFrameworkSpecflowUdemy
{
    public class AppConfigReader : IConfig
    {
        public BrowserType GetBrowser()
        {
            string browser = ConfigurationManager.AppSettings.Get(AppConfigKeys.Browser);
            try
            {
                return (BrowserType)Enum.Parse(typeof(BrowserType), browser);
            }
            catch
            {
                throw new NoSuitableDriverFound(string.Format("Driver Not Found : {0}", browser));
            }
        }

        /// <summary>
        /// Implicit wait
        /// </summary>
        public int GetElementLoadTimeOut()
        {
            int result;
            string timeout = ConfigurationManager.AppSettings.Get(AppConfigKeys.ElementLoadTimeout);
            if (int.TryParse(timeout, out result))
                return result;
            return 1;
        }

        public int GetPageLoadTimeOut()
        {
            int result;
            string timeout = ConfigurationManager.AppSettings.Get(AppConfigKeys.PageLoadTimeout);
            if (int.TryParse(timeout, out result))
                return result;
            return 20;
        }

        public string GetPassWord()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.Password);
        }

        public string GetScreenShotsFolder()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.ScreenShotsFolder);
        }

        public string GetUserName()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.UserName);
        }

        public string GetWebSiteUrl()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.WebSiteUrl);
        }
    }
}
