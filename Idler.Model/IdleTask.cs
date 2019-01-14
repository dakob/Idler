using Idler.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Idler.Model
{
    public class IdleTask: BindableBase
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                SetProperty(ref name, value);
            }
        }

        int Seconds { get; set; }

        private TimeSpan timeSpan;
        public virtual TimeSpan TimeSpan { get { return timeSpan; } set { SetProperty(ref timeSpan, value); } }

        private DateTime dateStart;
        public DateTime DateStart { get { return dateStart; } set { SetProperty(ref dateStart, value); } }

        private DateTime dateStop;
        public DateTime DateStop { get { return dateStop; } set { SetProperty(ref dateStop, value); } }




    }
}
