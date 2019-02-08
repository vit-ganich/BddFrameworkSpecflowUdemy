using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BddFrameworkSpecflowUdemy
{
    /// <summary>
    /// We can directly use the key from App.config file without using AppconfigKeys class, as below:
    /// 
    /// string browser = ConfigurationManager.AppSettings.Get("Browser");
    /// 
    /// So with the current implementation, it seems to be redundant. 
    /// But the point is the following method is getting called from multiple places:
    /// 
    /// ConfigurationManager.AppSettings.Get("Browser");
    /// 
    /// So in that case, if the key changes, then it will have to change it manually at multiple places.
    /// </summary>
    public class AppConfigKeys
    {
        public const string Browser = "Browser";
        public const string UserName = "UserName";
        public const string Password = "Password";
        public const string WebSiteUrl = "WebSiteUrl";
        public const string ScreenShotsFolder = "ScreenShotsFolder";
        public const string PageLoadTimeout = "PageLoadTimeout";
        public const string ElementLoadTimeout = "ElementLoadTimeout";
    }
}
