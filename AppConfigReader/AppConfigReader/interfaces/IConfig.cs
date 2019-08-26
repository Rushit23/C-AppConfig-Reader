using AppConfigReading.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppConfigReading.interfaces
{
    public interface IConfig
    {

        BrowserType GetBrowser();
        string GetUsername();
        string GetPassword();

    }
}
