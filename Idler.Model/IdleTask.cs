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
        public virtual string Name { get; set; }

        public int SDay { get; set; }

        public int SMonth { get; set; }

        public int SHour { get; set; }

        public int SMinutes { get; set; }

        public int EHour { get; set; }

        public int EMinutes { get; set; }
    }
}
