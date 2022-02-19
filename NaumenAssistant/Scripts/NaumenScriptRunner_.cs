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


}