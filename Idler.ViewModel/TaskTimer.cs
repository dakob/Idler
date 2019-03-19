using Idler.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Idler.Timer
{
    public class TaskTimer
    {
        System.Timers.Timer t;
        TaskVM TaskVM;

        public void Run(TaskVM taskVM)
        {
            TaskVM = taskVM;
            t = new System.Timers.Timer(1000)
            {
                AutoReset = true
            };
            t.Elapsed += T_Elapsed;
            t.Start();
        }

        public void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            TaskVM.TSpan = TaskVM.TSpan.Add(new TimeSpan(0, 0, 1));
            TaskVM.TimeSpan = String.Format("{0:0}D/{1:00}:{2:00}.{3:00}", TaskVM.TSpan.Days, TaskVM.TSpan.Hours, TaskVM.TSpan.Minutes, TaskVM.TSpan.Seconds);
        }

        public void Stop()
        {
            t.Stop();

            TaskVM.TimeSpan = String.Format("{0:0}D/{1:00}:{2:00}.{3:00}", TaskVM.TSpan.Days, TaskVM.TSpan.Hours, TaskVM.TSpan.Minutes, TaskVM.TSpan.Seconds);
        }
    }
}
