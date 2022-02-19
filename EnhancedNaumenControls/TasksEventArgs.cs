using System;

namespace EnhancedNaumenControls
{
    public class TasksEventArgs: EventArgs
    {
        public NamedTask[] Tasks {get; }

        public TasksEventArgs(NamedTask[] tasks)
        {
            Tasks = tasks ?? throw new ArgumentNullException(nameof(tasks));
        }
    }

}
