using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Idler.Timer;
using Shared;
using System;
using System.Timers;

namespace Idler.ViewModel
{
    public class TaskVM : BindableBase
    {
        public RelayCommand Start { get; private set; }
        public RelayCommand Stop { get; private set; }
        public RelayCommand Remove { get; private set; }

        public TaskVM()
        {
            Start = new RelayCommand(TimerStart);
            Stop = new RelayCommand(TimerStop);
            Remove = new RelayCommand(RemoveTask);
        }

        public int Id { get; set; }

        public Enums.Status Status { get; set; } = Enums.Status.NotStarted;

        string dateStart;
        public string DateStart
        {
            get
            {
                return DateTimeStart.ToShortDateString() + "/" + DateTimeStart.ToLongTimeString();
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
                return String.Format("{0:0}D/{1:00}:{2:00}.{3:00}", TSpan.Days, TSpan.Hours, TSpan.Minutes, TSpan.Seconds);
            }
            set
            {
                SetProperty(ref timeSpan, value);
            }
        }

        public string Name { get; set; }


        private void RemoveTask()
        {
            Messenger.Default.Send<TaskVM>(this, "RemoveTask");
        }

        internal TimeSpan TSpan;

        private DateTime? dateTimeStart = null;
        internal DateTime DateTimeStart
        {
            get
            { return dateTimeStart.Value; }
            set
            {
                dateTimeStart = value;
            }
        }

        #region Timer

        TaskTimer TaskTimer;
        public void TimerStart()
        {
            if (Status == Enums.Status.Pause || Status == Enums.Status.NotStarted)
            {
                if (Status == Enums.Status.NotStarted)
                {
                    DateTimeStart = DateTime.Now;
                    DateStart = DateTimeStart.ToShortDateString() + "/" + DateTimeStart.ToLongTimeString();
                }

                Status = Enums.Status.Run;
                TaskTimer = new TaskTimer();
                TaskTimer.Run(this);
            }
        }

        public void TimerStop()
        {
            if (Status == Enums.Status.Run)
            {
                TaskTimer.Stop();
                Status = Enums.Status.Pause;
            }
        }

        #endregion

    }
}
