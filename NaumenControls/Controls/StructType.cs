using System;
using NaumenControls.Lists;

namespace NaumenControls.Controls
{
    public enum StructType:int
    {        
        LSNum,
        LS,

        GettingComment,
        AddingComment,

        Connection,

        GettingFile,
        AddingFile,

        SetField,
    }

    internal static class StructTypeUtils
    {       
        public static IDataList NewDataList(this StructType structType)
        {
            switch (structType)
            {
                case StructType.LSNum:
                    return new LSNumList();

                case StructType.LS:
                    return new LSList();

                case StructType.GettingComment:
                    return new GettingCommentsList();

                case StructType.AddingComment:
                    return new AddingCommentsList();

                case StructType.Connection:
                    return new ConnectionsList();

                case StructType.GettingFile:
                    return new GettingFilesList();

                case StructType.AddingFile:
                    return new AddingFilesList();                
                
            }
            return null;
        }        
    }
}
