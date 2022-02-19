using System;
using System.Collections.Generic;
using System.Linq;
using CommonLib.LogHelper;
using NaumenAPI.Drivers;
using SPKCollections;

namespace NaumenAPI
{
    public enum LSComments : int
    {
        Date, Text, Author
    }

    public class NaumenLSComments : NaumenTab
    {
        #region STATIC
        public static BidirectDictionary<LSComments, string> Descriptor = new BidirectDictionary<LSComments, string>
        {
            [LSComments.Date] = "Дата",
            [LSComments.Text] = "Текст",
            [LSComments.Author] = "Автор",
        };

        public override string[] Header => Descriptor.Values.ToArray();
        
        #endregion STATIC

        internal NaumenLSComments(NaumenDriver naumenDriver) : base(naumenDriver)
        {
        }

        public override IEnumerable<string[]> Items
        {
            get
            {
                try
                {
                    if (mode != NMode.Offline)
                        driver.GotoTab("Comments");
                    //foreach (int c in new[] { 0, 1, 2 })
                    //{
                    //    Header[c] = browser.FindElementByCssSelector(
                    //        $@"#Comments\.BLCommentList > tbody > tr:nth-child(1) > td:nth-child({c + 1}) > b").Text;
                    //}

                    //Проедполагаем что порядок столбцов не меняется

                    return driver.GetDataList(
                    Header,
                    r =>
                    {
                        var row = new string[3];
                        foreach (int c in new[] { 0, 1, 2 })
                        {
                            row[c] = browser.FindElementByCssSelector(
                                $@"#Comments\.BLCommentList > tbody:nth-child(1) > tr:nth-child({r + 2}) > td:nth-child({c + 1})").Text;
                        }
                        return row;
                    });
                }
                catch (Exception ex)
                {
                    Log.Write(ex, $"{nameof(NaumenLSComments)}.GetItems");
                    return null;
                }

            }
        }
        //public IEnumerable<string[]> Items
        //{
        //    get
        //    {
        //        if (!naumenLS.Open()) return null;
        //        try
        //        {                    
        //            NaumenApi.NaumenDriver.GotoTab("Comments");
        //            ItemsHeader = new string[3];//LSCommentsDTO.Captions.Values.ToArray();

        //            foreach (int c in new[] { 0, 1, 2 })
        //            {
        //                ItemsHeader[c] = browser.FindElementByCssSelector(
        //                    $@"#Comments\.BLCommentList > tbody > tr:nth-child(1) > td:nth-child({c+1}) > b").Text;
        //            }

        //            return NaumenApi.NaumenDriver.GetDataList(ItemsHeader,
        //            r =>
        //            {
        //                var row = new string[3];
        //                foreach (int c in new[] { 0, 1, 2 })
        //                {
        //                    row[c] = browser.FindElementByCssSelector(
        //                        $@"#Comments\.BLCommentList > tbody:nth-child(1) > tr:nth-child({r + 2}) > td:nth-child({c + 1})").Text;
        //                }
        //                return row;
        //            });
        //        }
        //        catch (Exception ex)
        //        {
        //            Log.Write(ex, $"{nameof(NaumenLSComments)}.GetItems({naumenLS.Num})");
        //            return null;
        //        }                
        //    }
        //}

        //public override Dictionary<LSComments, string> Items
        //{
        //    get
        //    {
        //        if (!naumenLS.Open()) return null;
        //        try
        //        {
        //            NaumenApi.NaumenDriver.GotoTab("Comments");
        //            ItemsHeader = new string[3];//LSCommentsDTO.Captions.Values.ToArray();

        //            foreach (int c in new[] { 0, 1, 2 })
        //            {
        //                ItemsHeader[c] = browser.FindElementByCssSelector(
        //                    $@"#Comments\.BLCommentList > tbody > tr:nth-child(1) > td:nth-child({c + 1}) > b").Text;
        //            }

        //            return NaumenApi.NaumenDriver.GetDataList(ItemsHeader,
        //            r =>
        //            {
        //                var row = new string[3];
        //                foreach (int c in new[] { 0, 1, 2 })
        //                {
        //                    row[c] = browser.FindElementByCssSelector(
        //                        $@"#Comments\.BLCommentList > tbody:nth-child(1) > tr:nth-child({r + 2}) > td:nth-child({c + 1})").Text;
        //                }
        //                return row;
        //            });
        //        }
        //        catch (Exception ex)
        //        {
        //            Log.Write(ex, $"{nameof(NaumenLSComments)}.GetItems({naumenLS.Num})");
        //            return null;
        //        }
        //    }
        //}

        public bool Add(string text)
        {            
            if (text == null) return false;
            try
            {
                driver.GotoTab("Comments");
                browser.FindElementByLinkText("[добавить комментарий]").Click();

                driver.GotoWindow(1);
                var textArea = browser.FindElementById("title");
                textArea.SendKeys(text);

                if (mode == NMode.Release)
                    browser.FindElementById("confirm_outer").Click();

                return true;
            }
            catch (Exception ex)
            {
                Log.Write(ex, $"{nameof(NaumenLSComments)}.{nameof(Add)}({text})");
                return false;
            }
            finally
            {
                driver.GotoWindow(0);
            }
        }

        public bool Remove(string[] data)
        {
            //if (mode == NMode.Release) return true;
            throw new NotImplementedException();
        }

    }
}
