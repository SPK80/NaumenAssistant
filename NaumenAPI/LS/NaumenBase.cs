using System;
using NaumenAPI.Drivers;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace NaumenAPI
{
    public abstract class NaumenBase
    {
        //protected static NaumenDriver naumenDriver => NaumenApi.NaumenDriver ?? throw new Exception("NaumenDriver не доступен");
        //protected static ChromeDriver browser => naumenDriver.Browser ?? throw new Exception("Browser не доступен");

        protected NaumenDriver driver;
        protected RemoteWebDriver browser => driver.Browser;
        protected NaumenUser user => driver.User;

        protected NMode mode = NaumenApi.Mode;

        protected NaumenBase(NaumenDriver naumenDriver)
        {
            this.driver = naumenDriver ?? throw new ArgumentNullException(nameof(naumenDriver));
        }

        protected void login()
        {
            var loged = user?.Loged ?? throw new Exception("User не инициирован");
            if (!loged)
                throw new Exception("Проблема входа в Naumen");
        }
    }


    public enum NMode : int
    {
        //Default,
        Release, Readonly, Offline
    }

}
