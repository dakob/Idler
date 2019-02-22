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
        public TaskVM()
        {
            Start = new RelayCommand(TimerStart);
            Stop = new RelayCommand(TimerStop);
            OKCommand = new RelayCommand(okCommand);
            CancelCommand = new RelayCommand(cancelCommand);

        }


        public RelayCommand OKCommand { get; private set; }
        private void okCommand()
        {
            Messenger.Default.Send(new NotificationMessage("Close SpecialDesign Window"), "AddTaskView");
        }
        public RelayCommand CancelCommand { get; private set; }

        private void cancelCommand()
        {
            Messenger.Default.Send(new NotificationMessage("Close SpecialDesign Window"), "AddTaskView");
        }

        public int Id { get; set; }

        public Enums.Status Status { get; set; } = Enums.Status.NotStarted;

        string dateStart;
        public string DateStart
        {
            get
            {
                return dateStart;
            }
            set
            {
                if (String.IsNullOrEmpty(dateStart))
                {
                    SetProperty(ref dateStart, value);
                }
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
        internal TimeSpan TSpan;

        private DateTime? dtStart = null;
        internal DateTime DTStart
        {
            get
            { return dtStart.Value; }
            set
            {
                if (dtStart == null)
                {
                    dtStart = value;
                }
            }
        }
        internal DateTime DTStop;

        #region Timer

        TaskTimer TaskTimer;
        public void TimerStart()
        {
            if (Status == Enums.Status.Pause || Status == Enums.Status.NotStarted)
            {
               Status = Enums.Status.Run;
                DTStart = DateTime.Now;
                DateStart = DTStart.ToShortDateString() + "/" + DTStart.ToLongTimeString();
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
