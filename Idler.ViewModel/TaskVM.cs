using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Idler.Timer;
using Shared;
using System;

namespace Idler.ViewModel
{
    public class TaskVM : BindableBase
    {
        public RelayCommand StartPause { get; private set; }
        public RelayCommand Stop { get; private set; }
        public RelayCommand Remove { get; private set; }

        public TaskVM()
        {
            StartPause = new RelayCommand(TimerStart);
            Remove = new RelayCommand(RemoveTask);
        }

        public int Id { get; set; }

        Enums.Status status = Enums.Status.NotStarted;
        public Enums.Status Status
        {
            get => status;
            set
            {
                if (SetProperty(ref status, value))
                {
                    StatusText = status.ToString();
                }
            }
        }

        string statusText = Enums.Status.NotStarted.ToString();
        public string StatusText
        {
            get => statusText;
            set => SetProperty(ref statusText, value);
        }

        string dateStart;
        public string DateStart
        {
            get => dateTimeStart != null ? DateTimeStart.ToShortDateString() + "/" + DateTimeStart.ToLongTimeString() : "-";
            set => SetProperty(ref dateStart, value);
        }

        string timeSpan;
        public string TimeSpan
        {
            get => String.Format("{0:0}D/{1:00}:{2:00}.{3:00}", TSpan.Days, TSpan.Hours, TSpan.Minutes, TSpan.Seconds);
            set => SetProperty(ref timeSpan, value);
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
            get => dateTimeStart.HasValue ? dateTimeStart.Value : new DateTime(0);
            set => dateTimeStart = value;
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
            else if(Status == Enums.Status.Run)
            {
                TaskTimer.Stop();
                Status = Enums.Status.Pause;
            }
        }

        #endregion

    }
}
