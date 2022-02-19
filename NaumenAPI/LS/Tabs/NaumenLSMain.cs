using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using CommonLib.LogHelper;
using NaumenAPI.Drivers;
using OpenQA.Selenium.Chrome;
using SPKCollections;

namespace NaumenAPI
{
    public enum LSFields : int
    {
        LSNum, Type, Stage, Responsible, Curator, Contractor, ParentLS,
        Address, Client,
        Reason,
        Mark
    }

    
    public class NaumenLSMain : NaumenTab
    {
        #region STATIC
        public static BidirectDictionary<LSFields, string> Descriptor = new BidirectDictionary<LSFields, string>
        {
            [LSFields.LSNum] = "НомерЛС",
            [LSFields.Type] = "ТипЛС",
            [LSFields.Stage] = "Состояние",
            [LSFields.Responsible] = "Ответственный",
            [LSFields.Curator] = "Инициатор",
            [LSFields.Contractor] = "Подрядчик",
            [LSFields.ParentLS] = "ЛС-источник",
            [LSFields.Address] = "Адрес_Клиента",
            [LSFields.Client] = "Клиент",
            [LSFields.ParentLS] = "Основание",
            [LSFields.Mark] = "Маркировка",
        };

        public override string[] Header => Descriptor.Values.ToArray();
        


        #endregion STATIC

        internal NaumenLSMain(NaumenDriver naumenDriver) : base(naumenDriver)
        {
        }

        private string getFieldByID(string id)
        {
            try
            {
                driver.GotoTab("BuildList");
                return browser.FindElementById(id).Text;
            }
            catch (Exception ex)
            {
                Log.Write(ex, $"{nameof(NaumenLSMain)}.getFieldByID({id})");
                return null;
            }
        }

        private string getFieldByName(string name) => getFieldByID($"BuildList.BuildListParamCard.{name}");

        private string getAddress()
        {
            try
            {
                driver.GotoTab("BuildList");
                return browser.FindElementByXPath("/html/body/table/tbody/tr/td[2]/div/table/tbody/tr[2]/td[2]/table/tbody/tr[4]/td[2]/table[2]/tbody/tr/td/div[2]/div/table/tbody/tr[3]/td[2]").Text;
            }
            catch (Exception ex)
            {
                Log.Write(ex, $"{nameof(NaumenLSMain)}.getAddress");
                return null;
            }
        }

        private string getField(string name)
        {
            if (name == Descriptor[LSFields.Address])
            {
                return getAddress();
            }
            else
            {
                return getFieldByName(name);
            }
        }

        //private bool putField(LSFields key, string value)
        //{
        //    if (fields.ContainsKey(key))
        //    {
        //        fields[key] = value;
        //        return false;
        //    }
        //    else
        //    {
        //        fields.Add(key, value);
        //        return true;
        //    }
        //}

        //private Dictionary<LSFields, string> fields = new Dictionary<LSFields, string>();

        //private string[][] itemsCache;
        
        public override IEnumerable<string[]> Items
        {
            get
            {
                //var header = Descriptor.Values.ToArray();
                var values = new string[Header.Length];

                for (int i = 0; i < Header.Length; i++)
                {
                    values[i] = getField(Header[i]);
                }
                return new[] { Header, values };

                //putField(LSFields.Type, getFieldByName("Type"));
                //putField(LSFields.Stage, getFieldByName("Stage"));
                //putField(LSFields.Responsible, getFieldByName("Responsible"));
                //putField(LSFields.Curator, getFieldByName("Curator"));
                //putField(LSFields.Contractor, getFieldByName("Contractor"));
                //putField(LSFields.ParentLS, getFieldByName("blSource"));
                //putField(LSFields.Address, getAddress());
                //return fields;
            }
        }

        //public static BidirectionalDictionary<LSFields, string> Description = new BidirectionalDictionary<LSFields, string>();
               

        /// <summary>
        /// Тип
        /// </summary>
        //public string Type
        //{
        //    get => getField("Type");
        //}

        public bool SetStage(string stage, string responsible)
        {
            Dictionary<string, string> usersMap = new Dictionary<string, string>
            {
                ["Бухтийчук А. Б."] = "coreboo2k69gg0000hnv9ssq6ia3s5hs",
                ["Чернышева В. С."] = "corebofs000080000jk9adfn07f4uq8g",
                ["Суконкин П. К."] = "coreboo2k690g0000m2mjrph1ebuq4ro",
            };

            try
            {
                browser.FindElementByLinkText("[изменить состояние]").Click();
                driver.GotoWindow(1);
                browser.FindElementByXPath($"//*[@id=\"stage\"]/option[@nonshifted=\"{stage}\"]").Click();
                if (usersMap.ContainsKey(responsible))
                    browser.FindElementByXPath($"//*[@id=\"responsible\"]/option[@value=\"{usersMap[responsible]}\"]").Click();

                if (NaumenApi.Mode == NMode.Release)
                    browser.FindElementById("confirm").Click();

                //var error = browser.FindElementByClassName("error"); ?????
                return true;
            }
            catch
            {
                browser.Close();
                return false;
            }
            finally
            {
                driver.GotoWindow(0);
            }
        }

        public string Mark => getMark();

        private string getMark()
        {
            try
            {
                driver.GotoTab("BuildList");
                return browser.FindElementByXPath("/html/body/table/tbody/tr/td[2]/div/table/tbody/tr[2]/td[2]/table/tbody/tr[4]/td[2]/table[2]/tbody/tr/td/div[15]/div/table/tbody/tr[2]/td[2]").Text;
            }
            catch (Exception ex)
            {
                Log.Write(ex, $"{nameof(NaumenLSMain)}.getMark");
                return null;
            }
        }

        public bool SetMark(string mark)
        {
            try
            {
                driver.GotoTab("BuildList");
                browser.FindElementByXPath("//*[@alt = \"редактировать 'Выданная ОРЛКС маркировка строящегося кабеля'\"]").Click();
                driver.GotoWindow(1);
                browser.FindElementByXPath("//*[@id=\"value\"]").SendKeys(mark);

                if (mode== NMode.Release)
                    browser.FindElementByXPath("//*[@id=\"save\"]").Click();

                return true;
            }
            catch (Exception ex)
            {
                Log.Write(ex, $"{nameof(NaumenLSMain)}.getMark");
                return false;
            }
            finally
            {
                driver.GotoWindow(0);
            }
        }


        ///// <summary>
        ///// Тип
        ///// </summary>
        public string Type
        {
            get => getField("Type"); // "Stage"
        }


        ///// <summary>
        ///// Состояние
        ///// </summary>
        public string Stage
        {
            get => getField("Stage"); // "Stage"
        }


        ///// <summary>
        ///// Ответственный за состояние
        ///// </summary>
        public string Responsible
        {
            get => getField("Responsible");
        }
        /// <summary>
        /// Инициатор
        /// </summary>
        public string Curator
        {
            get => getField("Curator");
        }
        /// <summary>
        /// Подрядчик
        /// </summary>
        public string Contractor
        {
            get => getField("Contractor");
        }

        /// <summary>
        /// ЛС-источник
        /// </summary>
        public string ParentLS
        {
            get => getField("blSource");
        }

        ///// <summary>
        ///// Адрес клиента
        ///// </summary>
        public string Address => getAddress();


        //public string Client => getClient();
        //public string Osnovanie { get; }
        //public string ETO { get; }
        //public string Specprogram { get; }

    }
}
