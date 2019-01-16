using GalaSoft.MvvmLight.Command;
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
            Start = new RelayCommand(TimerStart);
            Stop = new RelayCommand(TimerStop);

        }

        int id;
        public int Id { get { return id; } set { SetProperty(ref id, value); } }

        public string DateStart
        {
            get
            {
                return dtStart.ToShortDateString() + "/" + dtStart.ToLongTimeString();
            }
        }

        public string TimeSpan
        {
            get
            {
                return String.Format("{0}D/{1:0}:{2:0}.{3:0}", tSpan.TotalDays, tSpan.TotalHours, tSpan.TotalMinutes, tSpan.TotalSeconds);
            }
        }

        string name;
        public string Name
        {
            get { return name; }
            set
            {
                SetProperty(ref name, value);
            }
        }

        public RelayCommand Start { get; private set; }
        public RelayCommand Stop { get; private set; }

        int Seconds { get; set; }
        private TimeSpan tSpan;
        private DateTime dtStart;
        private DateTime dtStop;


        static Timer t = new Timer(2000);

        public void TimerStart()
        {
            dtStart = DateTime.Now;
            t.AutoReset = true;
            t.Elapsed += T_Elapsed;
            t.Start();
        }

        private void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            new Action(() =>
            {
                

            }).Invoke();
        }

        public void TimerStop()
        {
            dtStop = DateTime.Now;
            t.Stop();
            tSpan = dtStop - dtStart;
        }

    }
}
