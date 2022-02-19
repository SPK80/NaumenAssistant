using System;
using System.Collections.Generic;
using System.Linq;
using ListScripts;
using NaumenAPI;

namespace NaumenAssistant.Scripts
{

    public class NaumenAPIAdapters
    {
        private static readonly Lazy<NaumenAPIAdapters> instanceHolder =
            new Lazy<NaumenAPIAdapters>(() => new NaumenAPIAdapters());

        public static NaumenAPIAdapters Instance(NaumenApi naumenApi)
        {
            var instance = instanceHolder.Value;
            instance.naumenApi = naumenApi;
            return instance;
        }

        public static string[] Names => instanceHolder.Value.items.Keys.ToArray();

        class NaumenAPIAdapter
        {
            public string[] InputFields;
            public Operation Operation;
        }

        private NaumenApi naumenApi=null;

        //public readonly Dictionary<string, string[]> InputFields = new Dictionary<string, string[]>();
        //public readonly Dictionary<string, NaumenOperation> Operations;

        private readonly Dictionary<string, NaumenAPIAdapter> items = new Dictionary<string, NaumenAPIAdapter>();

        //public string[] Names => items.Keys.ToArray();
        public Dictionary<string, string[]> InputFields => items.ToDictionary(kv =>kv.Key, kv=>kv.Value.InputFields);
        public Dictionary<string, Operation> Operations => items.ToDictionary(kv =>kv.Key, kv=>kv.Value.Operation);

        //public readonly Dictionary<string, NaumenAPIAdapter> adapters = new Dictionary<string, NaumenAPIAdapter>();

        //public static string[] AllNames => new NaumenAPIAdapters().items.Keys.ToArray();


        private NaumenAPIAdapters()
        {
            //this.NaumenApi = naumenApi;// ?? throw new ArgumentNullException(nameof(naumenApi));
            //Operations = null;
            //if (naumenApi != null) Operations = new Dictionary<string, NaumenOperation>();

            initSetMarkAPIAdapter();
            initGetCommentsAPIAdapter();
        }
         

        private string getInputValue(LSFields field, Dictionary<string, string> values) => values[NaumenLSMain.Descriptor[field]];

        private int getLsnum(Dictionary<string, string>  inputs)
        {
            int lsnum;
            if (int.TryParse(getInputValue(LSFields.LSNum, inputs), out lsnum))
            {
                return lsnum;
            }
            else return -1;
        }

        private void initSetMarkAPIAdapter()
        {
            items.Add("ДатьМаркировку", new NaumenAPIAdapter
            {
                InputFields = new[] { NaumenLSMain.Descriptor[LSFields.LSNum], NaumenLSMain.Descriptor[LSFields.Mark] },

                Operation = (inputs) =>
                {
                    if (naumenApi == null) return null;
                    var mark = getInputValue(LSFields.Mark, inputs);
                    var lsnum = getLsnum(inputs);
                    if (lsnum<0) return null;

                    bool result = naumenApi.OpenLS(lsnum)?.SetMark(mark) ?? false;
                    return new[]
                    {
                        new[] { "результат" },
                        new[] { result ? "успех" : "ошибка" }
                    };                    
                }
            });

            //Operations.Add("ДатьМаркировку",                
            //(lsnum, inputs) =>
            //{
            //    if (naumenApi == null) return null;
            //    var mark = getInputValue(LSFields.Mark, inputs);

            //    bool result = naumenApi.OpenLS(lsnum)?.SetMark(mark) ?? false;
            //    return new[]
            //    {
            //        new[] { "результат" },
            //        new[] { result ? "успех" : "ошибка" }
            //    };
            //});

            //InputFields.Add("ДатьМаркировку", new[] { NaumenLSMain.Descriptor[LSFields.LSNum], NaumenLSMain.Descriptor[LSFields.Mark] });
        }

        private void initGetCommentsAPIAdapter()
        {
            items.Add("ПолучитьКомментарии", new NaumenAPIAdapter
            {
                InputFields = new[] { NaumenLSMain.Descriptor[LSFields.LSNum] },
                Operation = (inputs) =>
                {
                    if (naumenApi == null) return null;
                    var lsnum = getLsnum(inputs);
                    if (lsnum < 0) return null;
                    return naumenApi.OpenLS(lsnum)?.Comments?.Items;
                }
            });

            //Operations.Add("ПолучитьКомментарии", (lsnum, inputs) =>
            //{
            //    if (naumenApi == null) return null;
            //    return naumenApi.OpenLS(lsnum)?.Comments?.Items;
            //});

            //InputFields.Add("ПолучитьКомментарии", new[] { NaumenLSMain.Descriptor[LSFields.LSNum] });
        }

    }

    //public static string GetInputValue(LSComments field, Dictionary<string, string> values) => values[NaumenLSComments.Descriptor[field]];
    //public static string GetInputValue(LSConnections field, Dictionary<string, string> values) => values[NaumenLSConnections.Descriptor[field]];
    //public static string GetInputValue(LSFiles field, Dictionary<string, string> values) => values[NaumenLSFiles.Descriptor[field]];


}
