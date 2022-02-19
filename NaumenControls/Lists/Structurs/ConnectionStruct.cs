using System;

namespace NaumenControls.Lists.Structures
{
    public class ConnectionStruct : IDataStruct
    {
        public ConnectionStruct(int lS, params string[] values)
        {
            //if (values.Length < 7) throw new ArgumentOutOfRangeException(nameof(values.Length));
            LS = lS;

            if (values.Length > 0) Addres = values[0];
            if (values.Length > 1) CableMark = values[1];
            if (values.Length > 2) NodeStation = values[2];
            if (values.Length > 3) Interval = values[3];
            if (values.Length > 4) Capacity = values[4];
            if (values.Length > 5) Comment = values[5];            
        }

        public int LS { get; set; }
        public string Addres { get; set; }
        public string CableMark { get; set; }
        public string NodeStation { get; set; }
        public string Interval { get; set; }
        public string Capacity { get; set; }
        public string Comment { get; set; }

        public string[] GetAllData()
        {
            return new string[6] { Addres, CableMark, NodeStation, Interval, Capacity, Comment };
        }
    }
}
