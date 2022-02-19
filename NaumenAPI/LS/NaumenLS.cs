using System;
using System.Linq;
using System.Collections.Generic;
using NaumenAPI.Drivers;
using CommonLib.LogHelper;

namespace NaumenAPI
{ 
    public class NaumenLS: NaumenBase
    {
        public int Num { get; }

        private NaumenLSMain main;
        public NaumenLSMain Main => main ?? (main = new NaumenLSMain(driver));

        private NaumenLSComments comments;
        public NaumenLSComments Comments => comments ?? (comments = new NaumenLSComments(driver));

        private NaumenLSFiles files;
        public NaumenLSFiles Files => files ?? (files = new NaumenLSFiles(driver));

        private NaumenLSConnections connections;
        public NaumenLSConnections Connections => connections ?? (connections = new NaumenLSConnections(driver));

        //public static NaumenLS Open(int num)
        //{
        //    var nls = new NaumenLS(num);
        //    if (nls.Open())
        //        return nls;
        //    else
        //        return null;
        //}

        private const string creatingLS = "http://moon:8090/fx/$guic/ru.naumen.guic.components.forms.form_jsp?uuid=coreboo2k69gg0000hnv9ojqg0m183k0&activeComponent=BuildList.WorkBuildList.BuildListList.BuildListListActionContainer.ObjectListReport.tableListAndButtons.ObjectsList.BuildListAdd";

        internal NaumenLS(NaumenDriver naumenDriver, int num) : base(naumenDriver)
        {
            Num = num;
        }

        //public void PrepareCreating(Dictionary<LSFields, string> fields)
        //{
        //    login();

        //    browser.Navigate().GoToUrl(creatingLS);

            
        //    browser.FindElementByXPath($"//select[@name='type']/option[@nonshifted='{fields[LSFields.Type]}']").Click(); //тип
        //    browser.FindElementById("client_search_str").SendKeys(fields[LSFields.Client]); //клиент

        //    browser.FindElementByName("client_search_button").Click();
        //    browser.FindElementByXPath("//select[@name='client']/option[@value='pstcimo2k69gg0000hnvp6ntdmgugt84']").Click();//TODO: исправить для произвольного клиента

        //    
        //    //browser.FindElementByXPath("//select[@name='stage']/option[@value='wstagefs000080000i7vpi32hvgvags4']"); //состояние

        //    browser.FindElementById("clientAddress").SendKeys(fields[LSFields.Address]); //адрес

        //    browser.FindElementById("reason").SendKeys(fields[LSFields.Reason]); //основание

        //    browser.FindElementById("curator_search_str").SendKeys(fields[LSFields.Curator]); //инициатор
        //    browser.FindElementByName("curator_search_button").Click();

        //    browser.FindElementById("responsible_search_str").SendKeys(fields[LSFields.Responsible]); //ответственный
        //    browser.FindElementByName("responsible_search_button").Click();
        //}

        //public static NaumenLS Create(Dictionary<LSFields, string> fields)
        //{
        //    PrepareCreating(fields);

        //    //browser.FindElementByName("confirm").Click();
        //    //var nls = new NaumenLS(0);
        //    //var url = nls.findLSURL(fields[LSFields.Address]);

        //    throw new NotImplementedException();

        //}

        private bool Opened=> this.driver.Browser.Title == Num.ToString();

        private string find(string text)
        {
            login();

            var searchString = browser.FindElementById("searchString");
            searchString.Clear();

            var numberOnly = browser.FindElementById("numberOnly");
            if (numberOnly.Selected) numberOnly.Click(); //снимаем гульку            
            

            searchString.SendKeys(text);
            browser.FindElementById("search").Click();
            browser.FindElementByLinkText("[отобразить/скрыть поля]").Click();


            driver.GotoWindow(1);

            //var f = browser.FindElementByXPath("//*[@value=\"con_address\"]");
            driver.SetChecked("//*[@value=\"con_address\"]", true);
            
            driver.ClickButton("//*[@id=\"ok\"]");
            try
            {
                browser.Close();
            }
            catch { }
            driver.GotoWindow(0);

            //browser.FindElementByLinkText(text).Click();

            return browser.Url;
        }

        private string findLSURL(int num)
        {
            login();

            var searchString = browser.FindElementById("searchString");
            searchString.Clear();

            var numberOnly = browser.FindElementById("numberOnly");
            if (!numberOnly.Selected) numberOnly.Click(); //устанавливаем гульку

            searchString.SendKeys(num.ToString());
            browser.FindElementById("search").Click();
            browser.FindElementByLinkText(num.ToString()).Click();

            if (Opened)
                return browser.Url;
            else return "";
        }

        public bool Open()
        {
            if (mode == NMode.Offline) return true;

            if (Opened) return true;
            try
            {
                if (findLSURL(Num) == "") return false;
                return true;
            }
            catch (Exception ex)
            {
                Log.Write(ex, $"OpenLS({Num})");
                return false;
            }
        }

        public bool Find(string text)
        {            
            return find(text)!="";
        }

        public bool SendToEconomist()
        {
            if (Main.SetStage("Оценка затрат на строительство", "Чернышева В. С.")) return true;
            if (Main.SetStage("Обработка экономистом", "Чернышева В. С.")) return true;

            return false;
        }

        public bool SendToShemCompile()
        {
            if (Main.SetStage("Составление схемы", user.ToString())) return true;

            return false;
        }

        public bool SetMark(string mark)
        {
            return Main.SetMark(mark);
        }
    }
}
