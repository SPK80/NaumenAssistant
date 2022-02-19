using System.Collections.Generic;
using ListScripts;
using NaumenAPI;
using SPKCollections;

namespace NaumenAssistant.Scripts
{
    //internal class NaumenAPIAdapter : APIAdapter
    //{
    //    public static string GetInputValue(LSFields field, Dictionary<string, string> values) => values[NaumenLSMain.Descriptor[field]];
        
    //    public NaumenAPIAdapter(string[] inputFields, NaumenOperation operation) :
    //        base(
    //            inputFields,
    //            (v) =>
    //            {                
    //                var strLSNum = GetInputValue(LSFields.LSNum, v);

    //                int lsnum;
    //                var results = int.TryParse(strLSNum, out lsnum) ? operation(lsnum, v): null;
                
                    
    //                return results;
    //            })
    //    { }
    //}

    //public delegate IEnumerable<string[]> NaumenOperation(int lsnum, Dictionary<string, string> values);
}
