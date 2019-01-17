using GalaSoft.MvvmLight.Command;
using System;
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

        string dateStart;
        public string DateStart
        {
            get
            {
                return dateStart;
            }
            set
            {
                SetProperty(ref dateStart, value);
            }
        }

        string timeSpan;
        public string TimeSpan
        {
            get
            {
                return timeSpan;
            }
            set
            {
                SetProperty(ref timeSpan, value);
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
            DateStart = dtStart.ToShortDateString() + "/" + dtStart.ToLongTimeString();
            t.AutoReset = true;
            t.Elapsed += T_Elapsed;
            t.Start();
        }

        private void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            new Action(() =>
            {
                tSpan = DateTime.Now - dtStart;
                TimeSpan = String.Format("{0:0}D/{1:0}:{2:0}.{3:0}", tSpan.TotalDays, tSpan.TotalHours, tSpan.TotalMinutes, tSpan.TotalSeconds);

            }).Invoke();
        }

        public void TimerStop()
        {
            t.Stop();
            tSpan = DateTime.Now - dtStart;
            TimeSpan = String.Format("{0:0}D/{1:0}:{2:0}.{3:0}", tSpan.TotalDays, tSpan.TotalHours, tSpan.TotalMinutes, tSpan.TotalSeconds);
        }

    }
}
