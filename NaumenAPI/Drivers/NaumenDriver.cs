using OpenQA.Selenium.Remote;

namespace NaumenAPI.Drivers
{
    public class NaumenDriver : ExtWebDriver
    {
        public NaumenDriver(RemoteWebDriver browser, string login, string password) : base(browser)
        {
            User = new NaumenUser(login, password, browser);
        }

        public NaumenUser User { get; }

        public bool GotoTab(string tabName)
        {
            var on_tab = Browser.FindElementByClassName("on_tab");
            var tab = Browser.FindElementById(tabName);
            if (on_tab.Text == tab.Text) return true;

            var url = Browser.Url;
            tab.Click();
            return url != Browser.Url;
        }

        public bool IsLSOpened(int num)
        {
            return Browser.Title == num.ToString();
        }

    }

}
