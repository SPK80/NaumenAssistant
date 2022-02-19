using System;
using System.Collections.Generic;

namespace ListScripts
{
    public abstract class APIAdapter
    {
        public APIAdapter(string[] inputFields, Operation operation)
        {
            InputFields = inputFields ?? throw new ArgumentNullException(nameof(inputFields));
            Operation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public string[] InputFields { get; }
        public Operation Operation { get; }
    }

    public delegate IEnumerable<string[]> Operation(Dictionary<string, string> values);

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

}
