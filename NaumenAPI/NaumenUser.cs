using NaumenAPI.Drivers;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;

namespace NaumenAPI
{
    public class NaumenUser
    {
        private const string loginURL = "http://moon:8090/fx/";
        
        private string name;

        private string login;
        private string userPassword;
        
        private bool loged = false;
        public bool Loged
        {
            get
            {
                if (loged) return true;

                try
                {
                    loged = false;
                    browser.Navigate().GoToUrl(loginURL);
                    browser.FindElementById("login1").SendKeys(login);
                    browser.FindElementById("password1").SendKeys(userPassword);

                    var url = browser.Url;
                    browser.FindElementByName("LogonFormSubmit").Click();
                    if (url != browser.Url)
                    {
                        logedURL = browser.Url;

                        name = browser.FindElementByXPath("//*[@id=\"publisher_div\"]/table/tbody/tr[2]/td[2]/table/tbody/tr[1]/td[2]/table/tbody/tr[2]/td").Text;

                        return loged = true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    loged = false;
                    return false;
                }
            }
        }

        public NaumenUser(string login, string password, RemoteWebDriver browser)
        {
            this.login = login ?? throw new ArgumentNullException(nameof(login));
            this.userPassword = password ?? throw new ArgumentNullException(nameof(password));
            this.browser = browser ?? throw new ArgumentNullException(nameof(browser));
        }


        private string logedURL;
        private string password;
        private RemoteWebDriver browser;



        public string LogedURL => loged ? logedURL : "";
        

        public override string ToString()
        {
            return name;
        }
    }
}
