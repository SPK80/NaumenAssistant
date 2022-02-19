namespace NaumenControls.Controls
{
    public class StructTypeWrap
    {
        public StructType StructType { get; }

        public StructTypeWrap(StructType structType)
        {
            this.StructType = structType;
        }

        public override string ToString()
        {
            switch (StructType)
            {
                case StructType.LSNum:
                    return "#ЛС";

                case StructType.LS:
                    return "ЛС";

                case StructType.GettingComment:
                    return "Комментарии";

                case StructType.AddingComment:
                    return "Комментарии";

                case StructType.Connection:
                    return "Привязки";

                case StructType.GettingFile:
                    return "Файлы";

                case StructType.AddingFile:
                    return "Файлы";

            }
            return "";
        }
    }


}
