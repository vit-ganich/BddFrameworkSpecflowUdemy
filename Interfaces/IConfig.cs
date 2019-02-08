using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BddFrameworkSpecflowUdemy
{
    public interface IConfig
    {
        BrowserType GetBrowser();
        string GetUserName();
        string GetPassWord();
        string GetWebSiteUrl();
        string GetScreenShotsFolder();
        int GetPageLoadTimeOut();
        int GetElementLoadTimeOut();
    }
}
