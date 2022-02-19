using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace ListScripts
{
    //public class ListScriptEditor : ListScriptFile
    //{
    //    private void inits()
    //    {
    //        Operations = new BindingList<string>(operations.ToList());
    //        InputFields = new BindingList<string>(inputFields.ToList());            
    //    }

    //    public BindingList<string> InputFields { get; private set; }
    //    public BindingList<string> Operations { get; private set; }
                
    //    public ListScriptEditor(string path, string[] inputFields, string[] operations) : 
    //        base(path, inputFields, operations)
    //    {            
    //        inits();
    //        saved = false;
    //    }

    //    public ListScriptEditor(string path) :
    //        base(path)
    //    {
    //        inits();
    //        saved = true;
    //    }

    //    private bool saved=false;

    //    public void Save()
    //    {
    //        operations = Operations.ToArray();            
    //        inputFields = InputFields.ToArray();
    //        save();
    //    }

    //    public bool Rename(string newName)
    //    {
    //        var dir = Path.GetDirectoryName(path);
    //        var ext = Path.GetExtension(path);

    //        var newPath = Path.Combine(dir, newName + ext);
    //        if (saved)
    //        {
    //            try
    //            {
    //                File.Move(path, newPath);
    //                path = newPath;
    //                return true;
    //            }
    //            catch
    //            {
    //                return false;
    //            }
    //        }
    //        else
    //        {
    //            path = newPath;
    //            return true;
    //        }
    //    }

    //    protected void save()
    //    {
    //        //var dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Path.GetDirectoryName(path));
    //        var dir = Path.GetDirectoryName(path);
    //        if (!Directory.Exists(dir))
    //            Directory.CreateDirectory(dir); // Создаем директорию, если нужно

    //        using (var writer = new StreamWriter(path))
    //        {
    //            writer.WriteLine(InputFields.Aggregate((s1, s2) => s1 + inputFieldsSeparator + s2));
    //            foreach (var op in Operations)
    //            {
    //                writer.WriteLine(op);
    //            }
    //            saved = true;
    //        }
    //    }
    //}    
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

