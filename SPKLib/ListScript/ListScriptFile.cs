using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ListScripts
{
    public abstract class ListScriptFile
    {
        protected string[] inputFields;
        protected string[] operations;

        protected string path;
        
        protected const char inputFieldsSeparator = '\t';
        
        protected ListScriptFile(string path, string[] inputFields, string[] operations)
        {
            this.path = path ?? throw new ArgumentNullException(nameof(path));
            this.inputFields = inputFields ?? throw new ArgumentNullException(nameof(inputFields));
            this.operations = operations ?? throw new ArgumentNullException(nameof(operations));
        }

        protected ListScriptFile(string path)
        {
            this.path = path ?? throw new ArgumentNullException(nameof(path));
            load();
        }
        
        protected void load()
        {   
            using (var reader = new StreamReader(path))
            {
                inputFields = reader.ReadLine().Split(inputFieldsSeparator);
                string line;
                var ops = new List<string>();
                while ((line = reader.ReadLine()) != null)
                {
                    ops.Add(line);
                }
                operations = ops.ToArray();
            }
        }

        protected static string getName(string path) => Path.GetFileNameWithoutExtension(path);

        public override string ToString() => getName(path);
        
        public bool Rename(string newName)
        {
            var dir = Path.GetDirectoryName(path);
            var ext = Path.GetExtension(path);

            var newPath = Path.Combine(dir, newName + ext);
            //if (saved)
            //{
                try
                {
                    File.Move(path, newPath);
                    path = newPath;
                    return true;
                }
                catch
                {
                    return false;
                }
            //}
            //else
            //{
            //    path = newPath;
            //    return true;
            //}
        }


        private bool saved = false;

        public void Save()
        {
            //var dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Path.GetDirectoryName(path));
            var dir = Path.GetDirectoryName(path);
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir); // Создаем директорию, если нужно

            using (var writer = new StreamWriter(path))
            {
                writer.WriteLine(inputFields.Aggregate((s1, s2) => s1 + inputFieldsSeparator + s2));
                foreach (var op in operations)
                {
                    writer.WriteLine(op);
                }
                saved = true;
            }
        }

        public void Remove()
        {
            File.Delete(path);
        }

    }
    //public delegate ITable<string, string> Operation(Dictionary<string, string> values);
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

