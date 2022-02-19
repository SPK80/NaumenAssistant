using System;
using System.Collections.Generic;

namespace NaumenAPI
{   
    //internal class Operations
    //{
    //    private static NaumenLS openLS(string[] values)
    //    {
    //        int num;            
    //        if (!int.TryParse(values[0].ToString(), out num))
    //            throw new ArgumentException($"Номер ЛС ({values[0]}) задан неверно");

    //        var nls  = NaumenApi.OpenLS(num);            
    //        if (nls == null)
    //            throw new ArgumentException($"Не удалось открыть ЛС {num}");

    //        return nls;
    //    }

    //    private static void throwIfNullOrNotEnoughValues(string[] values, int needfulCount)
    //    {
    //        if (values == null)
    //            throw new ArgumentNullException(nameof(values));
    //        if (values.Length < needfulCount)
    //            throw new ArgumentException($"Передано неодстаточно данных. Необходимо не менее {needfulCount}");
    //    }

    //    private static Dictionary<string, Func<string[], IEnumerable<string[]>>> operations = new Dictionary<string, Func<string[], IEnumerable<string[]>>>
    //    {            
    //        ["ПолучитьКомментарии"] = (values) => openLS(values).Comments?.Items,
    //        ["ПолучитьПривязки"] = (values) => openLS(values).Connections?.Items,
    //        ["ПолучитьФайлы"] = (values) => openLS(values).Files?.Items,

    //        ["ДобавитьКомментарий"] = (values) => 
    //        {
    //            throwIfNullOrNotEnoughValues(values, 2);
    //            var nls = openLS(values);
    //            var comments = nls.Comments;
    //            if (comments==null)
    //                throw new ArgumentException($"Не удалось открыть комментарии ЛС {nls.Num}");

    //            if (comments.Add(values[1]))
    //                return new[] { new[] { nls.Num.ToString(), "Комментарий добавлен" } };
    //            else
    //                throw new Exception($"Не удалось добавить комментарий в ЛС {nls.Num}");
    //        },

    //        ["ПолучитьПараметрыЛС"] = (values) =>
    //        {
    //            throwIfNullOrNotEnoughValues(values, 2);
    //            var nls = openLS(values);
    //            var main = nls.Main;
    //            if (main==null)
    //                throw new ArgumentException($"Не удалось открыть параметры ЛС {nls.Num}");
    //            var results = new List<string>();
    //            for (int i=1; i < values.Length; i++)
    //            {
    //                if (values[i] == "Тип") results.Add(main.Type);
    //                else
    //                    if (values[i] == "Состояние") results.Add(main.Stage);
    //                else
    //                    if (values[i] == "Ответственный") results.Add(main.Responsible);
    //                else
    //                    if (values[i] == "Инициатор") results.Add(main.Curator);
    //                else
    //                    if (values[i] == "Подрядчик") results.Add(main.Contractor);
    //                else
    //                    if (values[i] == "ЛС-источник") results.Add(main.ParentLS);
    //                else
    //                    if (values[i] == "Адрес") results.Add(main.Address);
    //            }
    //            return new[] { results.ToArray() };

    //        },
    //    };

       
    //    public static Func<string[], IEnumerable<string[]>> Recognize(string word)
    //    {
    //        if (operations.ContainsKey(word))
    //            return operations[word];
    //        else return null;
    //    }
       
    //}

}
