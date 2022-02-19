namespace NaumenControls.Lists.Structures
{
    public class LSNumStruct : IDataStruct
    {
        public LSNumStruct(int lS, params string[] values)
        {
            LS = lS;
            
            if (values.Length > 0) Result = values[0];
        }
        public int LS { get; set; }
        public string Result { get; set; }

        public string[] GetAllData()
        {
            return new string[1] { Result };
        }
    }
}
