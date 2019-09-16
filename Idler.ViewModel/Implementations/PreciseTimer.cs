using System;
using System.Runtime.InteropServices;
using Idler.ViewModel.Interfaces;

namespace Idler.ViewModel.Implementations
{
    internal class PreciseTimer : ITimer
    {
        private int mTimerId;
        private TimerEventHandler mHandler;  // NOTE: declare at class scope so garbage collector doesn't release it!!!

        public TaskVM TaskVM { get; set; }

        public void Run(TaskVM taskVM)
        {
            TaskVM = taskVM;

            timeBeginPeriod(1);
            mHandler = new TimerEventHandler(TimerCallback);
            mTimerId = timeSetEvent(1000, 0, mHandler, IntPtr.Zero, EVENT_TYPE);
        }

        public void Stop()
        {

            int err = timeKillEvent(mTimerId);
            mTimerId = 0;
            timeEndPeriod(1);
            // Ensure callbacks are drained
            System.Threading.Thread.Sleep(100);

            updateTimeSpan();
            TaskVM.Status = Shared.Enums.Status.Completed;
        }

        private void TimerCallback(int id, int msg, IntPtr user, int dw1, int dw2)
        {
            TaskVM.TSpan = TaskVM.TSpan.Add(new TimeSpan(0, 0, 1));
            updateTimeSpan();
        }
        private void updateTimeSpan()
        {
            TaskVM.TimeSpan = String.Format("{0:0}D/{1:00}:{2:00}.{3:00}", TaskVM.TSpan.Days, TaskVM.TSpan.Hours, TaskVM.TSpan.Minutes, TaskVM.TSpan.Seconds);
        }

        // P/Invoke declarations
        private delegate void TimerEventHandler(int id, int msg, IntPtr user, int dw1, int dw2);
        private const int TIME_PERIODIC = 1;
        private const int EVENT_TYPE = TIME_PERIODIC;// + 0x100;  // TIME_KILL_SYNCHRONOUS causes a hang ?!
        [DllImport("winmm.dll")]
        private static extern int timeSetEvent(int delay, int resolution, TimerEventHandler handler, IntPtr user, int eventType);
        [DllImport("winmm.dll")]
        private static extern int timeKillEvent(int id);
        [DllImport("winmm.dll")]
        private static extern int timeBeginPeriod(int msec);
        [DllImport("winmm.dll")]
        private static extern int timeEndPeriod(int msec);
    }
}

