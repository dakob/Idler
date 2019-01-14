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

        public TimeSpan TimeSpan { get; set; }

        public DateTime Date { get; set; } = new DateTime();

        static Timer t;

        public void TimerStart()
        {
            t = new Timer(2000);
            t.AutoReset = true;
            t.Start();
            t.Elapsed += T_Elapsed;
            
        }

        private void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            Date.AddMilliseconds(t.Interval);

        }

        public void TimerStop()
        {
            Date.AddMilliseconds(t.Interval);
            t.Stop();
        }
    }
}
