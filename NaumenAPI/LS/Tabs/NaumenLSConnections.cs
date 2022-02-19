using System;
using System.Collections.Generic;
using System.Linq;
using CommonLib.Extentions;
using CommonLib.JsonUtils;
using CommonLib.LogHelper;
using NaumenAPI.Drivers;
using OpenQA.Selenium;
using SPKCollections;
using SPKCollections.Extentions;

namespace NaumenAPI
{
    public enum LSConnections : int
    {
        Number, ConnectPoint, CableMark, NodeStation, Interval, Capacity, Comment
    }
    
    public class NaumenLSConnections : NaumenTab
    {
        protected int lastConnectionNum()
        {
            var num = browser.FindElementByXPath("//*[@id=\"Connection.LinksList.LinksListActionContainer.ObjectListReport.tableListAndButtons.ObjectsList\"]/tbody/tr[2]/td[1]/a");
            int result = 0;

            int.TryParse(num.Text, out result);

            return result;
        }

        #region STATIC

        public static BidirectDictionary<LSConnections, string> Descriptor = new BidirectDictionary<LSConnections, string>
        {            
            [LSConnections.ConnectPoint] = "Точка_подключения",
            [LSConnections.CableMark] = "Маркировка",
            [LSConnections.NodeStation] = "Узел",
            [LSConnections.Interval] = "Длина",
            [LSConnections.Capacity] = "Ёмкость",
            [LSConnections.Comment] = "Комментарий",
            [LSConnections.Number] = "Номер",
        };

        public override string[] Header => Descriptor.Values.ToArray();

        #endregion STATIC

        internal NaumenLSConnections(NaumenDriver naumenDriver) : base(naumenDriver)
        {
        }

        public override IEnumerable<string[]> Items
        {
            get
            {                
                try
                {
                    driver.GotoTab("Connection");
                    return driver.GetDataList(
                        Header,                    
                        r =>
                        {
                            var number = browser.FindElementById("Link.LinkMainCard.number").Text;
                            //var linkPoint = browser.FindElementById("Link.LinkMainCard.linkPoint").Text;
                            var connectPoint = browser.FindElementById("Link.LinkMainCard.well").Text;
                            var cableMark = browser.FindElementById("Link.LinkMainCard.cableMark").Text;
                            var nodeStation = browser.FindElementById("Link.LinkMainCard.nodeStation").Text;
                            var interval = browser.FindElementById("Link.LinkMainCard.nodeStationInterval").Text;
                            //var freeFiberNumbers = browser.FindElementById("Link.LinkMainCard.freeFiberNumbers").Text;
                            //var fiberCount = browser.FindElementById("Link.LinkMainCard.fiberCount").Text;
                            var cableCapacity = browser.FindElementById("Link.LinkMainCard.cableCapacity").Text;
                            var comment = browser.FindElementById("Link.LinkExtCard.comment").Text;

                            return new string[7] { connectPoint, cableMark, nodeStation, interval, cableCapacity, comment, number };
                        },                    
                        r => browser.FindElementByXPath(
                            $"//table[@id='Connection.LinksList.LinksListActionContainer.ObjectListReport." +
                            $"tableListAndButtons.ObjectsList']/tbody/tr[{r + 2}]/td[1]").Click(),

                        () => browser.Navigate().Back()
                        );
                }
                catch (Exception ex)
                {
                    Log.Write(ex, $"{nameof(NaumenLSConnections)}.GetItems");
                    return null;
                }
            }
        }


        public int Add(string[] data)
        {
            var _data = data.ReplaceNull("");
            try
            {
                driver.GotoTab("Connection");
                browser.FindElementByLinkText("[добавить]").Click();

                driver.GotoWindow(1);

                browser.FindElementByCssSelector("#location_outer > td:nth-child(2) > input:nth-child(4)").Click();//клик по радиокнопке "Точка подключения"

                browser.FindElementById("well").SendKeys(_data[0]);
                browser.FindElementById("cableMark").SendKeys(_data[1]);
                browser.FindElementById("nodeStation").SendKeys(_data[2]);
                browser.FindElementById("nodeStationInterval").SendKeys(_data[3]);
                browser.FindElementById("cableCapacity").SendKeys(_data[4]);

                int result = default;
                browser.FindElementById("exit").Click();
                driver.GotoWindow(0);
                result = lastConnectionNum();

                return result;
            }
            catch (Exception ex)
            {
                Log.Write(ex, $"{nameof(NaumenLSConnections)}.{nameof(Add)}({Json.Serialize(data)})");
                return default;
            }
            finally
            {
                driver.GotoWindow(0);
            }

        }


        public bool AddComment(int number, string text)
        {
            try
            {
                driver.GotoTab("Connection");
                var editButton = findConnectionEditExtraButton(number);
                if (editButton == null) return false;

                editButton.Click();

                driver.GotoWindow(1);

                var comment = browser.FindElementById("comment");
                comment.SendKeys(text);

                browser.FindElementById("confirm_outer").Click();
                return true;
            }
            catch (Exception ex)
            {
                Log.Write(ex, $"{nameof(NaumenLSConnections)}.{nameof(AddComment)}({text})");
                return false;
            }
            finally
            {
                driver.GotoWindow(0);
            }

        }

        /// <summary>
        /// поиск кнопки редактирования доп параметров привязки
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private IWebElement findConnectionEditExtraButton(int number)
        {
            IWebElement editButton;
            int r = 2;
            while (true)
            {
                try
                {
                    editButton = browser.FindElementByXPath(
                        $"/html/body/table/tbody/tr/td[2]/div/table/tbody/tr[2]/td[2]/table/tbody/tr[4]/td[2]/table[2]/tbody/tr/td/form/div/table/tbody/tr/td/div/table[1]/tbody/tr[3]/td/div/table/tbody/tr[{r}]/td[9]/a/img");
                    var title = editButton.GetAttribute("title");

                    if (title.StartsWith($@"редактировать доп. параметры '№{number}"))
                        return editButton;
                    r++;
                }
                catch (NoSuchElementException ex)
                {
                    return null;
                }
            }
        }
    }
}