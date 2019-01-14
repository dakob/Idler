using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Idler.Model
{
    public class IdleTask
    {
        public string Name { get; set; }

        int Seconds { get; set; }
        public TimeSpan TimeSpan { get; set; }

        public DateTime DateStart { get; set; }
        public DateTime DateStop { get; set; }


        static Timer t = new Timer(2000);

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
