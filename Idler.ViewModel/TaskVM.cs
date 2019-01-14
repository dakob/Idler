using GalaSoft.MvvmLight.Command;
using Idler.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Idler.ViewModel
{
    public class TaskVM : BindableBase
    {
        public TaskVM()
        {
            StartTask = new RelayCommand(TimerStart);
            PauseTask = new RelayCommand(TimerStop);

        }

        static Timer t = new Timer(2000);
        private DateTime DateStart;
        private int Seconds;

        public RelayCommand StartTask { get; private set; }
        public RelayCommand PauseTask { get; private set; }

        public DateTime DateStop { get; private set; }
        public TimeSpan TimeSpan { get; private set; }

        public void TimerStart()
        {
            DateStart = DateTime.Now;
            t.AutoReset = true;
            t.Elapsed += T_Elapsed;
            t.Start();
        }

        private void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            new Action(() =>
            {
                Seconds += 2;

            }).Invoke();
        }

        public void TimerStop()
        {
            //Date.AddMilliseconds(t.Interval);
            DateStop = DateTime.Now;
            t.Stop();
            TimeSpan = DateStop - DateStart;
        }
    }
}
