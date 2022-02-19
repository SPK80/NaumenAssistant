using System;
using CommonLib.LogHelper;
using NaumenAPI.Drivers;
using OpenQA.Selenium.Chrome;

namespace NaumenAPI
{
    public class NaumenApi : IDisposable
    {        
        private NaumenDriver naumenDriver;

        public static NMode Mode = NMode.Release;

        public void Dispose()
        {
            Close();
        }

        public void Close()
        {
            if (naumenDriver == null) return;
            naumenDriver.Dispose();
            naumenDriver = null;
        }

        public NaumenApi(string login, string password)
        {
            try
            {
                var chromeDriver = new ChromeDriver();
                naumenDriver = new NaumenDriver(chromeDriver, login, password);
            }
            catch(Exception ex)
            {
                Log.Write(ex);
                return;
            }
        }

        public NaumenLS OpenLS(int lS) {
            var result = new NaumenLS(naumenDriver, lS);            
            return result.Open()? result: null;
        }       
    }
}
