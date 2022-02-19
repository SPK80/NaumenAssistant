using System;

namespace NaumenControls.Lists.Structures
{

    public class FilesInfoStruct: IDataStruct
    {
        public FilesInfoStruct(int lS, params string[] values)
        {
            //if (values.Length < 6) throw new ArgumentOutOfRangeException(nameof(values.Length));
            LS = lS;

            if (values.Length > 0) Name = values[0];
            if (values.Length > 1) Type = values[1];
            if (values.Length > 2) Description = values[2];
            if (values.Length > 3) Size = values[3];
            if (values.Length > 4) Date = values[4];
            if (values.Length > 5) Author = values[5];
                 
        }
        public int LS { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public string Date { get; set; }
        public string Author { get; set; }        

        public string[] GetAllData()
        {
            return new string[6] { Name, Type, Description, Size, Date, Author };
        }
    }

    public class OneParamStruct : IDataStruct
    {
        public OneParamStruct(int lS, string data)
        {
            LS = lS;
            Data = data;
        }

        public int LS { get; set; }
        public string Data { get; set; }

        public string[] GetAllData()
        {
            return new string[1] { Data };
        }
    }

}
