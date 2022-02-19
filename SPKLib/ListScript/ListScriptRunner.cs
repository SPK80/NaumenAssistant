using System;
using System.Linq;
using System.Collections.Generic;
using SPKCollections;

namespace ListScripts
{
    public class ListScriptRunner: ListScriptFile
    {        
        public event EventHandler<TableEventArgs> Result;
        public event EventHandler<FailEventArgs> Fail;

        //public ListScriptRunner(string path, Dictionary<string, APIAdapter> APIAdapters) :
        //    base(path)
        //{
        //    this.APIAdapters = APIAdapters ?? throw new ArgumentNullException(nameof(APIAdapter));
        //}

        public ListScriptRunner(string path, Dictionary<string, Operation> operations) : base(path)
        {
            Operations = operations ?? throw new ArgumentNullException(nameof(operations));
        }

        public bool Run(Dictionary<string, string> values)
        {
            IEnumerable<string[]> allResults = null;
            
            foreach (var operation in operations)
            {
                //var opResult = GetAPIAdapter(operation)?.Operation?.Invoke(values).ToList();
                var opResult = Operations[operation].Invoke(values).ToList();

                if (opResult == null)
                {
                    var failEventArgs = new FailEventArgs(allResults, values);
                    Fail?.Invoke(this, failEventArgs);

                    if (!failEventArgs.Continue)
                        return false;
                }
                else
                {
                    if (allResults == null)
                        allResults = opResult;
                    else
                        allResults = new MergingDecorator<string>(allResults, opResult, "");
                }
            }

            Result?.Invoke(this, new TableEventArgs(allResults, values));
            return true;
        }

        //private APIAdapter GetAPIAdapter(string operationName)
        //{
        //    if (APIAdapters.ContainsKey(operationName))
        //        return APIAdapters[operationName];
        //    else return null;
        //}

        //private Dictionary<string, APIAdapter> APIAdapters;
        private Dictionary<string, Operation> Operations;

    }
}


//private static Dictionary<string, NaumenOperation> operations = new Dictionary<string, NaumenOperation>
//{
//    ["ПолучитьКомментарии"] = (values, captions) => openLS(values).Comments?.Items,
//    ["ПолучитьПривязки"] = (values, captions) => openLS(values).Connections?.Items,
//    ["ПолучитьФайлы"] = (values, captions) => openLS(values).Files?.Items,

//    ["ДобавитьКомментарий"] = (values, captions) =>
//    {
//        throwIfNullOrNotEnoughValues(values, 2);
//        var nls = openLS(values);
//        var comments = nls.Comments;
//        if (comments == null)
//            throw new ArgumentException($"Не удалось открыть комментарии ЛС {nls.Num}");

//        if (comments.Add(values[1]))
//            return new[] { new[] { nls.Num.ToString(), "Комментарий добавлен" } };
//        else
//            throw new Exception($"Не удалось добавить комментарий в ЛС {nls.Num}");
//    },

//    ["ПолучитьПараметрыЛС"] = (values, captions) =>
//    {
//        throwIfNullOrNotEnoughValues(values, 2);
//        var nls = openLS(values);
//        var main = nls.Main;
//        if (main == null)
//            throw new ArgumentException($"Не удалось открыть параметры ЛС {nls.Num}");
//        var results = new List<string>();
//        for (int i = 1; i < values.Length; i++)
//        {
//            if (values[i] == "Тип") results.Add(main.Type);
//            else
//                if (values[i] == "Состояние") results.Add(main.Stage);
//            else
//                if (values[i] == "Ответственный") results.Add(main.Responsible);
//            else
//                if (values[i] == "Инициатор") results.Add(main.Curator);
//            else
//                if (values[i] == "Подрядчик") results.Add(main.Contractor);
//            else
//                if (values[i] == "ЛС-источник") results.Add(main.ParentLS);
//            else
//                if (values[i] == "Адрес") results.Add(main.Address);
//        }
//        return new[] { results.ToArray() };

//    },
//};

