using System;
using System.Collections.Generic;
using CommonLib;
using EnhancedNaumenControls;

namespace NaumenAssistant.Scripts
{
    public class NaumenTaskArgs
    {
        public NaumenTaskArgs(string scriptName, IEnumerable<string[]> inputTable, StringTableView stringTableView, Flags flags)
        {
            ScriptName = scriptName ?? throw new ArgumentNullException(nameof(scriptName));
            Flags = flags;
            //SingleRowResults = singleRowResults;
            //InsertEmptyRow = insertEmptyRow;
            StringTableView = stringTableView ?? throw new ArgumentNullException(nameof(stringTableView));
            InputTable = inputTable ?? throw new ArgumentNullException(nameof(inputTable));
        }

        public string ScriptName  { get; }
        public bool SingleRowResults { get; }
        //public bool InsertEmptyRow { get; }
        public Flags Flags { get; }
        public StringTableView StringTableView  { get; }
        public IEnumerable<string[]> InputTable { get; }

    }

    //public class NaumenTaskArgs
    //{
    //    public NaumenTaskArgs(NaumenScriptRunner naumenScriptRunner, IEnumerable<string[]> inputTable)
    //    {
    //        NaumenScriptRunner = naumenScriptRunner ?? throw new ArgumentNullException(nameof(naumenScriptRunner));
    //        InputTable = inputTable ?? throw new ArgumentNullException(nameof(inputTable));
    //    }

    //    public NaumenScriptRunner NaumenScriptRunner { get; }
    //    public IEnumerable<string[]> InputTable { get; }

    //}

}
