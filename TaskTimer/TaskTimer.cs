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
            t = new System.Timers.Timer(1000);
            t.AutoReset = true;
            t.Elapsed += T_Elapsed;
            t.Start();
        }

                

        public void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            new Action(() =>
            {
                var tSpan = DateTime.Now - TaskVM.DTStart;
                var TimeSpan = String.Format("{0:0}D/{1:0}:{2:0}.{3:0}", tSpan.TotalDays, tSpan.TotalHours, tSpan.TotalMinutes, tSpan.TotalSeconds);

            }).Invoke();
        }

        public void Stop()
        {
            t.Stop();

        }

    }
}
