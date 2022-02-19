using System;
using System.Collections.Generic;
using OpenQA.Selenium.Remote;

namespace NaumenAPI.Drivers
{
    public class ExtWebDriver : IDisposable
    {
        public RemoteWebDriver Browser { get; private set; }

        public ExtWebDriver(RemoteWebDriver browser)
        {
            this.Browser = browser ?? throw new ArgumentNullException(nameof(browser));
        }

        public virtual void Dispose()
        {
            if (Browser == null) return;
            Browser.Quit();
            Browser = null;
        }

        public bool SetChecked(string xpath, bool value)
        {
            var checkBox = Browser.FindElementByXPath(xpath);
            if (checkBox.Selected != value)
                checkBox.Click();
            return checkBox.Selected;
        }

        public void ClickButton(string xpath)
        {
            var button = Browser.FindElementByXPath(xpath);
            button.Click();
        }


        public bool GotoWindow(string caption)
        {
            foreach (var w in Browser.WindowHandles)
            {
                var t = Browser.SwitchTo().Window(w).Title;
                if (t == caption)
                    return true;
            }
            return false;
        }

        public void GotoWindow(int num)
        {
            Browser.SwitchTo().Window(Browser.WindowHandles[num]);
        }

        public IEnumerable<string[]> GetDataList(
           string[] header,
           Func<int, string[]> recParser,
           Action<int> goInside = null,
           Action goOutside = null)
        {
            if (header != null)
                yield return header;
            int i = 0;
            while (true)
            {
                string[] values;
                try
                {
                    goInside?.Invoke(i);
                    values = recParser(i);
                    goOutside?.Invoke();
                }
                catch //(OpenQA.Selenium.NoSuchElementException ex)
                {
                    yield break;
                }

                yield return values;
                i++;
            }
        }
    }
}
