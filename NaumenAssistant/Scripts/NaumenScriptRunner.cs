using System;
using System.Collections.Generic;
using System.Linq;
using CommonLib;
using EnhancedNaumenControls;
using ListScripts;
using NaumenAPI;
using SPKCollections;

namespace NaumenAssistant.Scripts
{
    [Flags]
    public enum NsrOptions:int
    {
        singleRowResults = 1,
        insertEmptyRow = 2
    }    

    public class NaumenScriptRunner : ListScriptRunner
    {
        public NaumenScriptRunner(string name, NaumenApi naumenApi, StringTableView tableView, Flags flags) ://params NsrOptions[] flags) ://bool singleRowResults, bool insertEmptyRow) :
            base(NaumenScriptSettings.Path(name), 
                NaumenAPIAdapters.Instance(naumenApi).Operations.ToDictionary(kv=>kv.Key, kv=>(Operation)kv.Value))
        {
            bool headerInited = false;
            Result += (rs, re) => //обработчик результатов выполнения
            {
                Action action = () =>
                {
                    var results = flags.Contains(NsrOptions.singleRowResults)? TableSerializer.ToRow(re.Table) : re.Table;                    

                    var inputs = new[] { re.InputValues.Keys.ToArray(), re.InputValues.Values.ToArray() };
                    var inputsAndResults = new MergingDecorator<string>(inputs, results, "");
                    var resultTable = new TableDecorator<string>(inputsAndResults);

                    if (!headerInited)
                    {
                        tableView.ColumnCaptions = resultTable.Header;
                        headerInited = true;
                    }

                    foreach (var row in resultTable)
                    {
                        tableView.Rows.Add(row);
                    }

                    if (flags.Contains(NsrOptions.insertEmptyRow))
                        tableView.Rows.Add(new string[] { "" });
                };

                tableView.Invoke(action);
            };
        }
    }

    //public class NaumenScriptRunner : ListScriptRunner
    //{
    //    private static bool singleRowResults;
    //    private static readonly string lsNumDesc = NaumenLSMain.Descriptor[LSFields.LSNum];
    //    private static readonly string markDesc = NaumenLSMain.Descriptor[LSFields.Mark];
    //    private static readonly string commenTextDesc = NaumenLSComments.Descriptor[LSComments.Text];
    //    private static bool insertEmptyRow;

    //    public string[] Operations => operations;
    //    public string[] InputFields => inputFields;

    //    public static NaumenApi NaumenApi;

    //    public static bool ScriptDefinedNMode = false;

    //    public static Dictionary<string, APIAdapter> APIAdapters = new Dictionary<string, APIAdapter>
    //    {
    //        ["НаЭкономиста"] = new NaumenAPIAdapter( new[] { lsNumDesc }, singleRowResults,
    //        (lsnum, inputs) =>
    //        {
    //            insertEmptyRow = false;
    //            if (ScriptDefinedNMode)
    //                NaumenApi.Mode = NMode.Readonly;

    //            bool result = NaumenApi.OpenLS(lsnum)?.SendToEconomist() ?? false;
    //            var results = new[] {
    //                    new[] { "результат" },
    //                    new[] { result ? "отправлен" : "не отправлен" }
    //                };
    //            return results;
    //        }),

    //        ["ПрисвоитьМаркировку"] = new NaumenAPIAdapter( new[] { lsNumDesc, markDesc }, singleRowResults,
    //        (lsnum, inputs) =>
    //        {
    //            insertEmptyRow = false;
    //            if (ScriptDefinedNMode)
    //                NaumenApi.Mode = NMode.Readonly;

    //            var mark = NaumenAPIAdapter.GetInputValue(LSFields.Mark, inputs);
    //            bool result = NaumenApi.OpenLS(lsnum)?.SetMark(mark) ?? false;
    //            return new[]
    //            {
    //                new[] { "результат" },
    //                new[] { result ? "успех" : "ошибка" }
    //            };
    //        }),

    //        ["ДобавитьКомментарий"] = new NaumenAPIAdapter( new[] { lsNumDesc,  commenTextDesc}, singleRowResults,
    //        (lsnum, inputs) =>
    //        {
    //            //insertEmptyRow = false;
    //            if (ScriptDefinedNMode)
    //                NaumenApi.Mode = NMode.Release;
    //            var comments = NaumenApi.OpenLS(lsnum)?.Comments;
    //            var text = NaumenAPIAdapter.GetInputValue(LSComments.Text, inputs);
    //            var result  = comments.Add(text);
    //            return new[]
    //            {
    //                new[] { "результат" },
    //                new[] { result ? "успех" : "ошибка" }
    //            };
    //        }),

    //        ["ПолучитьКомментарии"] = new NaumenAPIAdapter( new[] { lsNumDesc }, singleRowResults,
    //        (lsnum, inputs) =>
    //        {
    //            //insertEmptyRow = false;
    //            if (ScriptDefinedNMode)
    //                NaumenApi.Mode = NMode.Readonly;

    //            return NaumenApi.OpenLS(lsnum)?.Comments?.Items;
    //        }),

    //        ["ПолучитьПривязки"] = new NaumenAPIAdapter( new[] { lsNumDesc }, singleRowResults,
    //        (lsnum, inputs) =>
    //        {
    //            //insertEmptyRow = false;
    //            if (ScriptDefinedNMode)
    //                NaumenApi.Mode = NMode.Readonly;

    //            return NaumenApi.OpenLS(lsnum)?.Connections?.Items;
    //        }),

    //        ["ПолучитьПараметры"] = new NaumenAPIAdapter( new[] { lsNumDesc }, singleRowResults,
    //        (lsnum, inputs) =>
    //        {
    //            //insertEmptyRow = false;
    //            if (ScriptDefinedNMode)
    //                NaumenApi.Mode = NMode.Readonly;

    //            var lsMain = NaumenApi.OpenLS(lsnum)?.Main;

    //            var header = new[]
    //            {
    //                    NaumenLSMain.Descriptor[LSFields.Address],
    //                    NaumenLSMain.Descriptor[LSFields.Type],
    //                    NaumenLSMain.Descriptor[LSFields.Stage],
    //                    NaumenLSMain.Descriptor[LSFields.Responsible],
    //                    //NaumenLSMain.Descriptor[LSFields.Mark],
    //            };
    //            var values = new[]
    //            {
    //                    lsMain.Address,
    //                    lsMain.Type,
    //                    lsMain.Stage,
    //                    lsMain.Responsible,
    //                    //lsMain.Mark
    //            };

    //            return new[] { header, values };
    //        }),
    //    };

    //    public NaumenScriptRunner(string name, StringTableView tableView, bool singleRowResults) : 
    //        base(NaumenScriptSettings.Path(name), APIAdapters)
    //    {
    //        NaumenScriptRunner.singleRowResults = singleRowResults;
    //        bool headerInited = false;
    //        Result += (rs, re) =>
    //        {
    //            Action action = () =>
    //            {
    //                var inputs = new[] { re.InputValues.Keys.ToArray(), re.InputValues.Values.ToArray() };
    //                var inputsAndResults = new MergingDecorator<string>(inputs, re.Table, "");
    //                var resultTable = new TableDecorator<string>(inputsAndResults);

    //                if (!headerInited)
    //                {
    //                    tableView.ColumnCaptions = resultTable.Header;
    //                    headerInited = true;
    //                }

    //                foreach (var row in resultTable)
    //                {
    //                    tableView.Rows.Add(row);
    //                }

    //                if (insertEmptyRow)
    //                    tableView.Rows.Add(new string[] { "" });

    //            };

    //            tableView.Invoke(action);
    //        };
    //    }


    //}  
}