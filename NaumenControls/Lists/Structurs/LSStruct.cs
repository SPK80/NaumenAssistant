namespace NaumenControls.Lists.Structures
{

    public class LSStruct : IDataStruct
    {
        private const int propertiesCount = 8;
        public LSStruct(int lS, params string[] values)
        {
            LS = lS;

            if (values.Length > 0) Type = values[0];
            if (values.Length > 1) Client = values[1];
            if (values.Length > 2) Addres = values[2];
            if (values.Length > 3) Osnovanie = values[3];
            if (values.Length > 4) Sostoyanie = values[4];
            if (values.Length > 5) Otvetstvenniy = values[5];
            if (values.Length > 6) Initciator = values[6];
            if (values.Length > 7) Specprogram = values[7];
        }

        public int LS { get; set; }
        public string Type { get; set; }
        public string Client { get; set; }
        public string Addres { get; set; }
        public string Osnovanie { get; set; }
        public string Sostoyanie { get; set; }
        public string Otvetstvenniy { get; set; }
        public string Initciator { get; set; }
        public string Specprogram { get; set; }

        public string[] GetAllData()
        {
            return new string[propertiesCount] { Type, Client, Addres, Osnovanie, Sostoyanie, Otvetstvenniy, Initciator, Specprogram };
        }
    }
}
