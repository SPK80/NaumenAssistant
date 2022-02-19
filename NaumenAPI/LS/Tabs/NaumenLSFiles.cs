using System;
using System.Collections.Generic;
using System.Linq;
using CommonLib.LogHelper;
using NaumenAPI.Drivers;
using SPKCollections;

namespace NaumenAPI
{
    public enum LSFiles : int
    {
        Name, Type, Description, Size, Date, Author
    }

    public class NaumenLSFiles : NaumenTab
    {
        
        #region STATIC

        public static BidirectDictionary<LSFiles, string> Descriptor = new BidirectDictionary<LSFiles, string>
        {
            [LSFiles.Name] = "Название",
            [LSFiles.Type] = "Тип",
            [LSFiles.Description] = "Описание",
            [LSFiles.Size] = "Размер",
            [LSFiles.Date] = "Дата",
            [LSFiles.Author] = "Автор",
        };

        public override string[] Header => Descriptor.Values.ToArray();

        #endregion STATIC

        internal NaumenLSFiles(NaumenDriver naumenDriver) : base(naumenDriver)
        {
        }

        public override IEnumerable<string[]> Items
        {
            get
            {
                try
                {
                    if (mode != NMode.Offline)
                        driver.GotoTab("Files");
                    return driver.GetDataList(
                    Header,
                    r =>
                    {
                        var values = new string[6];
                        for (int c = 0; c < 5; c++)
                        {
                            values[c] = browser.FindElementByCssSelector(
                                $@"#Files\.FilesList > tbody:nth-child(1) > tr:nth-child({r + 2}) > td:nth-child({c + 1})").Text;
                        }
                        values[6] = browser.FindElementByCssSelector(
                                $@"#Files\.FilesList > tbody:nth-child(1) > tr:nth-child({r + 2}) > td:nth-child({1}) > a:nth-child(1)").GetAttribute("href");

                        return values;
                    });
                }
                catch (Exception ex)
                {
                    Log.Write(ex, $"{nameof(NaumenLSFiles)}.GetItems");
                    return null;
                }
            }
        }

        public bool Add(string path)
        {
            if (path == null) return false;
            try
            {
                driver.GotoTab("Files");
                browser.FindElementByLinkText("[добавить]").Click();
                driver.GotoWindow(1);

                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                Log.Write(ex, $"{nameof(NaumenLSFiles)}.{nameof(Add)}({path})");
                return false;
            }
            finally
            {
                driver.GotoWindow(0);
            }
        }

    }
}