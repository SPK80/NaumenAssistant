using System;
using System.ComponentModel;
using System.Linq;
using CommonLib.LogHelper;
using NaumenAPI;
using SPKCollections;

namespace NaumenAssistant.Scripts
{
    public class NaumenScriptWorker : BackgroundWorker
    {
        public NaumenScriptWorker()
        {
            this.DoWork += NaumenScriptWorker_DoWork;
            this.WorkerReportsProgress = true;
        }

        private void NaumenScriptWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!(e.Argument is NaumenTaskArgs)) return;
            
            using (var naumenApi = new NaumenApi(User.Name, User.Password))
            {
                try
                {
                    var taskArgs = e.Argument as NaumenTaskArgs;
                    var rows = new DictionaryDecorator<string>(taskArgs.InputTable).ToArray();
                    
                    for (int i = 0; i < rows.Length; i++)
                    {
                        if (((BackgroundWorker)sender).CancellationPending) break;
                        
                        var naumenScriptRunner = new NaumenScriptRunner(taskArgs.ScriptName, naumenApi, taskArgs.StringTableView, taskArgs.Flags);

                        naumenScriptRunner.Run(rows[i]);

                        ReportProgress((i/ rows.Length)*100, $"выполнено {i+1} / {rows.Length}");
                    }
                }
                catch (Exception ex)
                {
                    Log.Write(ex, $"Ошибка {nameof(NaumenApi)} - {e.Argument}");
                }
            }
        }
    }

    public class NaumenScriptWorker_ : BackgroundWorker
    {
        public NaumenScriptWorker_()
        {
            this.DoWork += NaumenScriptWorker_DoWork;
            this.WorkerReportsProgress = true;
        }

        private void NaumenScriptWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!(e.Argument is NaumenTaskArgs)) return;
         
            using (var naumenApi = new NaumenApi(User.Name, User.Password))
            {
                try
                {                    
                    var taskArgs = e.Argument as NaumenTaskArgs;

                    //taskArgs.ScriptName

                    var inputRows = new DictionaryDecorator<string>(taskArgs.InputTable).ToArray();

                    var naumenScriptRunner = new NaumenScriptRunner(taskArgs.ScriptName, naumenApi, taskArgs.StringTableView, taskArgs.Flags);


                    //taskArgs.NaumenScriptRunner.HeaderInited = false;

                    for (int i = 0; i < inputRows.Length; i++)
                    {
                        if (((BackgroundWorker)sender).CancellationPending) break;                        

                        naumenScriptRunner.Run(inputRows[i]);

                        ReportProgress((i / inputRows.Length) * 100, $"выполнено {i + 1} / {inputRows.Length}");
                    }
                }
                catch (Exception ex)
                {
                    Log.Write(ex, $"Ошибка {nameof(NaumenApi)} - {e.Argument}");
                }
            }
        }
    }


}
